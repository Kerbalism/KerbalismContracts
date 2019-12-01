﻿using System;
using System.Collections.Generic;
using Contracts;
using KSP;
using ContractConfigurator;
using ContractConfigurator.Parameters;
using System.Linq;
using System.Text;
using UnityEngine;
using Contracts.Parameters;
using FinePrint;
using FinePrint.Utilities;
using ContractConfigurator.Behaviour;


namespace Kerbalism.Contracts
{
	public class SubParameter : ContractConfiguratorParameter
	{
		public SubParameter() { }
		public SubParameter(string title) : base(title) { }

		protected override void OnParameterLoad(ConfigNode node)
		{
		}

		protected override void OnParameterSave(ConfigNode node)
		{
		}

		public void SetTitle(string newTitle)
		{
			if (title != newTitle)
			{
				title = newTitle;

				// Force a call to GetTitle to update the contracts app
				GetTitle();
			}
		}
	}


	public abstract class BackgroundVesselParameter : ContractConfiguratorParameter, ParameterDelegateContainer
 	{
		private readonly Dictionary<Guid, bool> validCandidates = new Dictionary<Guid, bool>();

		private float lastUpdate = 0.0f;
		private const float UPDATE_FREQUENCY = 1f;

		protected bool condition_met = false;
		protected bool allow_interruption = true;
		protected double duration = -1;
		protected double endTime = double.MaxValue;
		private SubParameter durationParameter;

		public bool ChildChanged { get; set; }

		protected BackgroundVesselParameter() : base() { }
		protected BackgroundVesselParameter(string title) : base(title) { }

		public void SetDuration(double value)
		{
			duration = value;
		}

		public void SetAllowInterruption(bool value)
		{
			allow_interruption = value;
		}

		protected void CreateTimerParameter()
		{
			if (duration > 0.0 && durationParameter == null)
			{
				durationParameter = new SubParameter("Duration: " + DurationUtil.StringValue(duration));
				durationParameter.Optional = true;
				durationParameter.fakeOptional = true;
				AddParameter(durationParameter);
			}
		}

		protected override void OnParameterLoad(ConfigNode node)
		{
			title = ConfigNodeUtil.ParseValue(node, "title", string.Empty);
			condition_met = ConfigNodeUtil.ParseValue(node, "condition_met", false);
			allow_interruption = ConfigNodeUtil.ParseValue(node, "allow_interruption", false);
			duration = Convert.ToDouble(node.GetValue("duration"));
			endTime = Convert.ToDouble(node.GetValue("endTime"));
			validCandidates.Clear();
		}

		protected override void OnParameterSave(ConfigNode node)
		{
			if(!string.IsNullOrEmpty(title)) node.SetValue("title", title);
			node.SetValue("condition_met", condition_met);
			node.SetValue("allow_interruption", allow_interruption);
			node.AddValue("duration", duration);
			node.AddValue("endTime", endTime);
		}

		protected virtual void BeforeUpdate() { }
		protected virtual void AfterUpdate() { }

		protected override void OnUpdate()
		{
			base.OnUpdate();

			if (state != ParameterState.Incomplete) return;
			if (Time.fixedTime - lastUpdate < UPDATE_FREQUENCY) return;

			BeforeUpdate();

			lastUpdate = Time.fixedTime;

			bool was_condition_met = condition_met;
			condition_met = false;
			foreach (Vessel vessel in FlightGlobals.Vessels)
			{
				if (IsValidCandidate(vessel)) condition_met |= VesselMeetsCondition(vessel);
			}

			AfterUpdate();

			double now = Planetarium.GetUniversalTime();
			if (condition_met)
			{
				if(endTime == double.MaxValue)
				{
					endTime = now + duration - 1;
				}

				if(endTime < now)
				{
					SetState(ParameterState.Complete);
				}
			}
			else
			{
				// condition not met
				if (was_condition_met && !allow_interruption)
				{
					// interruption not allowed -> fail
					SetState(ParameterState.Failed);
				}
				else
				{
					// interruptions allowed, reset timer
					endTime = double.MaxValue;
				}
			}

			GetTitle();

			CreateTimerParameter();
			if (durationParameter != null)
			{
				if(condition_met)
					durationParameter.SetTitle("Time Remaining: " + DurationUtil.StringValue(endTime - Planetarium.GetUniversalTime()));
				else
					durationParameter.SetTitle("Duration: " + DurationUtil.StringValue(duration));

				durationParameter.SetState(condition_met ? ParameterState.Incomplete : ParameterState.Failed);
			}
		}

		protected bool IsValidCandidate(Vessel vessel)
		{
			switch(vessel.vesselType)
			{
				case VesselType.Debris:
				case VesselType.Flag:
				case VesselType.SpaceObject:
				case VesselType.Unknown:
					return false;
			}

			if(!validCandidates.ContainsKey(vessel.id))
			{
				validCandidates[vessel.id] = VesselIsCandidate(vessel);
			}

			return validCandidates[vessel.id];
		}

		/// <summary>
		/// Method to determine if a vessel is a potential candidate for this parameter.
		/// Called on parameter load, so the implementation isn't too performance critical.
		/// If this method returns false, VesselMeetsCondition will not be called for this vessel.
		/// </summary>
		/// <param name="vessel">can be loaded or unloaded</param> 
		protected abstract bool VesselIsCandidate(Vessel vessel);

		/// <summary>
		/// The actual parameter check.
		/// </summary>
		/// <param name="vessel">can be loaded or unloaded</param>
		/// <returns>true if completed, false otherwise</returns>
		protected abstract bool VesselMeetsCondition(Vessel vessel);
	}
}
