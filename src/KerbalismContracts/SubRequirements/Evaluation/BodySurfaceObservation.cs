﻿using System;
using System.Collections.Generic;

namespace KerbalismContracts
{
	public class Surface
	{
		internal bool visible;
		//internal string name;
		internal Vector3d normal;

		public Surface(string name, double x, double y, double z)
		{
			//this.name = name;
			normal = new Vector3d(x, y, z).normalized;
		}
	}

	public static class BodySurfaceObservation
	{
		public static double VisibleSurface(List<Vessel> vessels, EvaluationContext context, Vector3d bodyPosition, double minElevation, List<Surface> surfaces)
		{
			Reset(surfaces);
			int visibleSurfaces = 0;
			foreach (Vessel v in vessels)
			{
				Vector3d vesselPosition = context.VesselPosition(v);
				Vector3d viewDirection = (vesselPosition - bodyPosition);

				double R = context.targetBody.Radius;
				double a = R;
				double b = R + context.Altitude(v, context.targetBody);
				double c = Math.Sqrt(a * a + b * b);
				double α = Math.Asin(b / c) * 180.0 / Math.PI;

				visibleSurfaces += MarkVisibleSurfaces(viewDirection.normalized, α - minElevation, surfaces);
			}

			return visibleSurfaces / (double)surfaces.Count;
		}

		/// <summary>
		/// For details, see misc/polyhedron/README.txt
		/// </summary>
		public static List<Surface> CreateVisibleSurfaces()
		{
			var surfaces = new List<Surface>();

			surfaces.Add(new Surface("face_169", 0.230680626242, -0.964193041172, -0.130836646365));
			surfaces.Add(new Surface("face_168", 0.250322476561, 0.915543467829, 0.314831409241));
			surfaces.Add(new Surface("face_165", -0.116745620927, 0.935035390548, -0.334782434453));
			surfaces.Add(new Surface("face_164", -0.226978258254, -0.26869312651, -0.936100888818));
			surfaces.Add(new Surface("face_167", -0.536401719777, 0.138996169332, -0.832438141805));
			surfaces.Add(new Surface("face_166", -0.932438238399, -0.356662556779, -0.0578856818557));
			surfaces.Add(new Surface("face_161", 0.97468146136, 0.172280067444, -0.142532898807));
			surfaces.Add(new Surface("face_160", -0.126909255174, 0.618660947823, 0.775340359191));
			surfaces.Add(new Surface("face_163", -0.753945005546, -0.232980413842, 0.614236970051));
			surfaces.Add(new Surface("face_162", -0.987136340509, -0.0973965665478, -0.126790197062));
			surfaces.Add(new Surface("face_8", -0.45752891947, -0.888875177502, -0.0238370860093));
			surfaces.Add(new Surface("face_9", -0.387585068644, -0.0605050354427, -0.919846158469));
			surfaces.Add(new Surface("face_4", 0.125051928238, 0.959954217239, -0.250698855299));
			surfaces.Add(new Surface("face_5", 0.889344139453, -0.388385159376, 0.241296435109));
			surfaces.Add(new Surface("face_6", 0.943992643517, -0.0215229202906, -0.3292638044));
			surfaces.Add(new Surface("face_7", 0.363167896295, -0.756101779315, 0.544443916688));
			surfaces.Add(new Surface("face_0", 0.218025974713, -0.966419487629, 0.13600753024));
			surfaces.Add(new Surface("face_1", 0.79671794984, 0.414771356567, 0.439551169006));
			surfaces.Add(new Surface("face_2", 0.690477917513, -0.290882480406, 0.662289685878));
			surfaces.Add(new Surface("face_3", -0.679658268946, 0.276722784231, -0.679329918479));
			surfaces.Add(new Surface("face_49", -0.419156433501, -0.343317810107, 0.840500306673));
			surfaces.Add(new Surface("face_48", -0.663464497204, 0.741976741422, 0.0963606565896));
			surfaces.Add(new Surface("face_45", -0.316910060129, -0.530919876309, -0.785933902265));
			surfaces.Add(new Surface("face_44", -0.294686943802, 0.179392868508, 0.938604178491));
			surfaces.Add(new Surface("face_47", 0.464788024067, 0.37629786218, 0.801481136149));
			surfaces.Add(new Surface("face_46", -0.810706268066, -0.585352448676, 0.010856230804));
			surfaces.Add(new Surface("face_41", 0.713319477316, 0.650883396183, -0.25985789935));
			surfaces.Add(new Surface("face_40", 0.435809722441, -0.371155323213, -0.819947322623));
			surfaces.Add(new Surface("face_43", -0.579678063704, 0.52555972805, -0.622704034604));
			surfaces.Add(new Surface("face_42", 0.814132608946, -0.579918186315, 0.0297151852048));
			surfaces.Add(new Surface("face_29", -0.502970237813, 0.719534309647, -0.478843729326));
			surfaces.Add(new Surface("face_28", -0.466655612535, 0.379699081263, 0.798787297707));
			surfaces.Add(new Surface("face_27", -0.869770090203, 0.199737420141, -0.451226055525));
			surfaces.Add(new Surface("face_26", -0.605290936091, 0.775491959044, -0.179541371681));
			surfaces.Add(new Surface("face_25", -0.000185533295799, -0.389017767178, 0.921230233111));
			surfaces.Add(new Surface("face_24", 0.476404024461, 0.796700283119, 0.371897653065));
			surfaces.Add(new Surface("face_23", 0.352160826331, -0.13476942353, 0.926185702157));
			surfaces.Add(new Surface("face_22", -0.645622095006, 0.677543470622, 0.352288171613));
			surfaces.Add(new Surface("face_21", -0.178517456019, 0.784249396733, 0.594209055485));
			surfaces.Add(new Surface("face_20", 0.653253910444, -0.665913036811, -0.360304254617));
			surfaces.Add(new Surface("face_190", -0.170592396237, -0.709973371601, -0.683254012768));
			surfaces.Add(new Surface("face_191", -0.964355450428, 0.172197543625, -0.200914337965));
			surfaces.Add(new Surface("face_192", 0.363800308452, 0.0762972334189, -0.9283469544));
			surfaces.Add(new Surface("face_193", -0.466001556596, 0.884783100857, -0.00118898645327));
			surfaces.Add(new Surface("face_194", 0.936786814115, -0.349554306021, -0.0155644480209));
			surfaces.Add(new Surface("face_195", 0.767523366064, -0.445854512048, -0.460566647329));
			surfaces.Add(new Surface("face_196", -0.927453006195, -0.0337606647015, -0.372412592186));
			surfaces.Add(new Surface("face_197", 0.591991156025, 0.801852483996, -0.0811114362916));
			surfaces.Add(new Surface("face_198", -0.395304662172, -0.730488892212, -0.556884370781));
			surfaces.Add(new Surface("face_199", 0.576093230752, -0.698302056038, 0.424842121282));
			surfaces.Add(new Surface("face_118", 0.827795830745, 0.0768568160722, -0.555740130298));
			surfaces.Add(new Surface("face_119", 0.245896647913, 0.317477135015, 0.915829191109));
			surfaces.Add(new Surface("face_110", 0.654656191133, 0.735691797112, 0.173732124472));
			surfaces.Add(new Surface("face_111", 0.175714594923, 0.0762711288612, 0.98148209155));
			surfaces.Add(new Surface("face_112", 0.234710043507, -0.89508631082, -0.379119627109));
			surfaces.Add(new Surface("face_113", 0.767986635035, 0.456195511365, -0.449535520085));
			surfaces.Add(new Surface("face_114", -0.0855594745918, -0.472361935304, -0.877242143529));
			surfaces.Add(new Surface("face_115", -0.76525169529, 0.423483757563, -0.484820946264));
			surfaces.Add(new Surface("face_116", -0.380856442992, -0.0687891045614, 0.922071813323));
			surfaces.Add(new Surface("face_117", 0.339816899803, -0.585681016008, -0.735868345627));
			surfaces.Add(new Surface("face_58", -0.601930448942, -0.431108782677, 0.672179255954));
			surfaces.Add(new Surface("face_59", -0.00196134120695, -0.957289893751, -0.289123178701));
			surfaces.Add(new Surface("face_52", 0.791211274491, 0.611171173219, -0.0213193842337));
			surfaces.Add(new Surface("face_53", 0.618229028952, -0.772272667215, 0.1462456674));
			surfaces.Add(new Surface("face_50", 0.413956539157, -0.863253297678, 0.288848970463));
			surfaces.Add(new Surface("face_51", 0.752409949287, -0.599629992293, 0.272622707337));
			surfaces.Add(new Surface("face_56", 0.00401785633147, 0.972768718796, 0.231743126245));
			surfaces.Add(new Surface("face_57", -0.5017384783, -0.817489655178, 0.282788194715));
			surfaces.Add(new Surface("face_54", 0.443688371135, 0.888223524246, 0.119162075742));
			surfaces.Add(new Surface("face_55", -0.25496274402, 0.958730060309, -0.12581999293));
			surfaces.Add(new Surface("face_38", 0.595375600795, 0.638585316583, -0.487582492941));
			surfaces.Add(new Surface("face_39", -0.429559772383, 0.753298085754, 0.498016461525));
			surfaces.Add(new Surface("face_34", 0.488216034415, 0.617818492081, 0.616397124088));
			surfaces.Add(new Surface("face_35", 0.0434106230681, 0.877508832624, 0.477591631493));
			surfaces.Add(new Surface("face_36", 0.318141586843, -0.58880508776, 0.743030618042));
			surfaces.Add(new Surface("face_37", 0.606063311313, 0.120488153546, -0.786237793251));
			surfaces.Add(new Surface("face_30", 0.0487850533964, 0.502284295034, -0.863325260563));
			surfaces.Add(new Surface("face_31", 0.209096725036, 0.976440914979, 0.0533075898305));
			surfaces.Add(new Surface("face_32", -0.298215533382, 0.20389982423, -0.932465740566));
			surfaces.Add(new Surface("face_33", -0.0805339608552, -0.870261815654, 0.485961576016));
			surfaces.Add(new Surface("face_183", -0.226668920522, -0.873104801568, -0.431635501261));
			surfaces.Add(new Surface("face_182", 0.119206198008, -0.771433041659, 0.625044754072));
			surfaces.Add(new Surface("face_181", -0.589271569666, -0.153698881431, 0.79318073037));
			surfaces.Add(new Surface("face_180", -0.725113171339, -0.628808146273, 0.280733332421));
			surfaces.Add(new Surface("face_187", -0.105580073419, 0.680085799315, -0.725490285026));
			surfaces.Add(new Surface("face_186", 0.0898846682567, 0.719619672355, 0.688526160413));
			surfaces.Add(new Surface("face_185", 0.924669941183, 0.0150507922972, 0.380472040398));
			surfaces.Add(new Surface("face_184", -0.678688884651, 0.316429270328, 0.662762336536));
			surfaces.Add(new Surface("face_189", -0.531567157431, 0.132011413108, 0.836665610593));
			surfaces.Add(new Surface("face_188", 0.778711674872, -0.0499504738945, 0.625390340168));
			surfaces.Add(new Surface("face_109", -0.106680007124, 0.00499465819209, 0.994280860456));
			surfaces.Add(new Surface("face_108", -0.904942593454, -0.293416980308, -0.308196979576));
			surfaces.Add(new Surface("face_103", -0.0484481909962, 0.258723480072, -0.964735680717));
			surfaces.Add(new Surface("face_102", 0.20456275885, 0.296141039441, -0.932981544539));
			surfaces.Add(new Surface("face_101", -0.593021091751, 0.549974014302, 0.588094013174));
			surfaces.Add(new Surface("face_100", 0.865300373791, -0.226877652338, 0.446969567182));
			surfaces.Add(new Surface("face_107", -0.719235068834, 0.0548463570865, 0.692598579896));
			surfaces.Add(new Surface("face_106", 0.271428853847, -0.180913965048, -0.945302340286));
			surfaces.Add(new Surface("face_105", -0.275201153808, -0.908233276019, 0.315240608542));
			surfaces.Add(new Surface("face_104", -0.535424566022, -0.541469483095, -0.648175387512));
			surfaces.Add(new Surface("face_81", -0.00193140741195, -0.843571321669, -0.537013682249));
			surfaces.Add(new Surface("face_80", -0.992802147281, 0.111072181664, 0.0447980670869));
			surfaces.Add(new Surface("face_83", 0.48553907459, 0.808233268699, -0.333182818307));
			surfaces.Add(new Surface("face_82", -0.772721736921, 0.043532378014, -0.633250384409));
			surfaces.Add(new Surface("face_85", 0.642415852136, 0.16474558408, 0.748438885582));
			surfaces.Add(new Surface("face_84", 0.446103089624, -0.750657539551, -0.487345146424));
			surfaces.Add(new Surface("face_87", 0.660891214705, -0.742297614895, -0.110530779636));
			surfaces.Add(new Surface("face_86", 0.0211891598158, -0.223392290749, -0.97449828319));
			surfaces.Add(new Surface("face_89", -0.578910157606, -0.649057460222, 0.49354578587));
			surfaces.Add(new Surface("face_88", 0.656558681268, 0.625745501544, 0.421157055442));
			surfaces.Add(new Surface("face_138", 0.464291817439, -0.851162954051, -0.244856557827));
			surfaces.Add(new Surface("face_139", -0.617936927944, -0.0959199389235, -0.780354610674));
			surfaces.Add(new Surface("face_136", 0.64885340491, 0.411859994697, 0.639812944308));
			surfaces.Add(new Surface("face_137", -0.617372454903, -0.664649822042, -0.420822843945));
			surfaces.Add(new Surface("face_134", -0.46131856935, 0.848844247146, 0.258163943379));
			surfaces.Add(new Surface("face_135", 0.892418170823, 0.242763771824, -0.38033611382));
			surfaces.Add(new Surface("face_132", -0.198525453719, -0.238224374048, 0.950703314307));
			surfaces.Add(new Surface("face_133", -0.920968420339, 0.302186357893, 0.24596864402));
			surfaces.Add(new Surface("face_130", -0.818651218042, -0.189252716986, -0.542211759658));
			surfaces.Add(new Surface("face_131", 0.257126012967, 0.859548767276, -0.441658386233));
			surfaces.Add(new Surface("face_98", 0.251349595209, -0.382545068364, 0.889090913044));
			surfaces.Add(new Surface("face_99", -0.0225793382037, -0.970503507814, 0.240027320958));
			surfaces.Add(new Surface("face_96", -0.0207477652571, 0.998867491452, -0.0428166411201));
			surfaces.Add(new Surface("face_97", 0.223074699645, -0.764055741079, -0.605356508929));
			surfaces.Add(new Surface("face_94", -0.351063417428, -0.778021078258, 0.520996812591));
			surfaces.Add(new Surface("face_95", -0.794735726965, 0.601047854265, -0.0844784065266));
			surfaces.Add(new Surface("face_92", 0.991716488902, -0.0984748064922, -0.0824688918707));
			surfaces.Add(new Surface("face_93", 0.922972825122, 0.258901768917, 0.284764882205));
			surfaces.Add(new Surface("face_90", -0.220101000034, 0.412677900993, 0.883884890592));
			surfaces.Add(new Surface("face_91", -0.240035684741, -0.954145557637, -0.178855038769));
			surfaces.Add(new Surface("face_121", 0.0165658152786, 0.848330181875, -0.529208348654));
			surfaces.Add(new Surface("face_120", -0.452495291548, -0.316621934805, -0.833665737287));
			surfaces.Add(new Surface("face_123", 0.146179170474, 0.704823396092, -0.694158217153));
			surfaces.Add(new Surface("face_122", -0.372054915797, 0.601604111291, 0.706857576114));
			surfaces.Add(new Surface("face_125", 0.0620947043926, -0.598454525277, 0.798746786449));
			surfaces.Add(new Surface("face_124", 0.443254017666, -0.896327134158, 0.0111150526524));
			surfaces.Add(new Surface("face_127", -0.406127402806, -0.592586002203, 0.69563090981));
			surfaces.Add(new Surface("face_126", 0.303852451303, 0.521439433031, -0.797354755123));
			surfaces.Add(new Surface("face_129", -0.809376368125, -0.535181499194, -0.241848418727));
			surfaces.Add(new Surface("face_128", -0.396111450648, 0.864794370014, -0.308587777233));
			surfaces.Add(new Surface("face_154", 0.814723927001, 0.187297944446, 0.548766255139));
			surfaces.Add(new Surface("face_155", -0.957963668261, 0.0416182346215, 0.283854774206));
			surfaces.Add(new Surface("face_156", -0.00796183471446, -0.999635779107, -0.025786010118));
			surfaces.Add(new Surface("face_157", 0.74377905825, -0.461464496584, 0.483573397636));
			surfaces.Add(new Surface("face_150", 0.380826662107, 0.701186528502, -0.602750782394));
			surfaces.Add(new Surface("face_151", -0.249417251906, -0.964938549789, 0.0817595840383));
			surfaces.Add(new Surface("face_152", -0.449221492459, 0.388031248514, -0.804755739893));
			surfaces.Add(new Surface("face_153", 0.356916044245, 0.922197754273, -0.148869873961));
			surfaces.Add(new Surface("face_158", 0.177647535672, -0.426956345312, -0.886650794996));
			surfaces.Add(new Surface("face_159", -0.703553147988, 0.621245025119, -0.345061714365));
			surfaces.Add(new Surface("face_16", -0.140295367267, -0.00531091620632, -0.990095452011));
			surfaces.Add(new Surface("face_17", -0.899861677453, -0.237125785303, 0.366087862945));
			surfaces.Add(new Surface("face_14", 0.990154385645, 0.0914791245923, 0.105952170111));
			surfaces.Add(new Surface("face_15", -0.219452995379, 0.899639304543, 0.377477819931));
			surfaces.Add(new Surface("face_12", -0.351692430248, 0.62298361795, -0.698715855174));
			surfaces.Add(new Surface("face_13", 0.429306519708, 0.118939053375, 0.895292920623));
			surfaces.Add(new Surface("face_10", 0.713659772907, 0.29334234667, -0.636113194474));
			surfaces.Add(new Surface("face_11", -0.820159655412, 0.543790698568, 0.177847732019));
			surfaces.Add(new Surface("face_18", -0.76590864674, -0.449186357013, 0.460016914387));
			surfaces.Add(new Surface("face_19", -0.638958247787, -0.764612296492, 0.0842638335077));
			surfaces.Add(new Surface("face_147", -0.211502541261, -0.505130598579, 0.836725614177));
			surfaces.Add(new Surface("face_146", -0.928545857692, 0.37121137488, -0.00216917565605));
			surfaces.Add(new Surface("face_145", -0.874897995309, 0.41392898343, -0.251428507694));
			surfaces.Add(new Surface("face_144", 0.653198698426, -0.335468470793, -0.678816886559));
			surfaces.Add(new Surface("face_143", -0.754331330485, -0.450985068047, -0.477070971918));
			surfaces.Add(new Surface("face_142", -0.845222531304, 0.222937156586, 0.485693212624));
			surfaces.Add(new Surface("face_141", 0.582911864269, -0.089196363241, 0.807624768862));
			surfaces.Add(new Surface("face_140", 0.484360919496, -0.34732839089, 0.80296792498));
			surfaces.Add(new Surface("face_149", 0.549099951072, 0.484409850186, -0.681055314035));
			surfaces.Add(new Surface("face_148", 0.564637415408, -0.55908624041, -0.607130270129));
			surfaces.Add(new Surface("face_63", -0.0230916595524, 0.252429475807, 0.967339720576));
			surfaces.Add(new Surface("face_62", 0.063425311284, -0.642363329054, -0.763771289966));
			surfaces.Add(new Surface("face_61", 0.293713460303, 0.779881422284, 0.552736257553));
			surfaces.Add(new Surface("face_60", -0.778109515525, 0.461733841508, 0.425849082957));
			surfaces.Add(new Surface("face_67", 0.877393671244, 0.435436242309, -0.201433921038));
			surfaces.Add(new Surface("face_66", -0.451823414032, -0.840833881405, -0.298083858023));
			surfaces.Add(new Surface("face_65", -0.151315338306, -0.713144561324, 0.684491419265));
			surfaces.Add(new Surface("face_64", 0.451552568221, 0.30961894871, -0.836801281508));
			surfaces.Add(new Surface("face_69", 0.711681782429, -0.092509623384, -0.696384240302));
			surfaces.Add(new Surface("face_68", 0.919251172732, -0.287196429067, -0.269249870126));
			surfaces.Add(new Surface("face_178", -0.882938734312, -0.425020730893, 0.199440642204));
			surfaces.Add(new Surface("face_179", -0.653375529007, -0.737158719122, -0.172329454584));
			surfaces.Add(new Surface("face_172", -0.205316952115, 0.458314831069, -0.864749943508));
			surfaces.Add(new Surface("face_173", 0.823172453639, 0.526025901868, 0.213737835055));
			surfaces.Add(new Surface("face_170", 0.9317911397, 0.360776491707, 0.0400698765532));
			surfaces.Add(new Surface("face_171", 0.0636374942046, 0.486211464422, 0.871520901181));
			surfaces.Add(new Surface("face_176", 0.546808328397, -0.543556346632, 0.636825839638));
			surfaces.Add(new Surface("face_177", 0.113484969786, 0.0402066366336, -0.99272583728));
			surfaces.Add(new Surface("face_174", 0.289772463345, 0.570310368533, 0.76862084478));
			surfaces.Add(new Surface("face_175", -0.24019365009, 0.961551424221, 0.133138533247));
			surfaces.Add(new Surface("face_70", 0.970718953164, -0.154645691213, 0.183818998359));
			surfaces.Add(new Surface("face_71", 0.842286407138, -0.200480177853, -0.500361176189));
			surfaces.Add(new Surface("face_72", 0.178989928864, -0.899377798708, 0.398851075661));
			surfaces.Add(new Surface("face_73", -0.250415372628, 0.808369730575, -0.532757468123));
			surfaces.Add(new Surface("face_74", 0.823530914116, -0.524589613169, -0.21587628691));
			surfaces.Add(new Surface("face_75", 0.0929049193914, -0.162580117368, 0.982311753666));
			surfaces.Add(new Surface("face_76", -0.978123422854, -0.167308917614, 0.123621582868));
			surfaces.Add(new Surface("face_77", -0.657089447231, -0.323686038543, -0.680779558146));
			surfaces.Add(new Surface("face_78", -0.862215612217, -0.029722931813, 0.505668651761));
			surfaces.Add(new Surface("face_79", 0.509828063014, -0.128682979244, -0.850597458858));

			return surfaces;
		}

		private static void Reset(List<Surface> surfaces)
		{
			foreach (Surface vs in surfaces)
				vs.visible = false;
		}

		private static int MarkVisibleSurfaces(Vector3d viewDirection, double α, List<Surface> surfaces)
		{
			int visibleSurfaces = 0;

			// we use the same view direction for all visible surfaces. This is wrong,
			// but the error should be small enough and can be neglected.
			foreach (Surface vs in surfaces)
			{
				if (!vs.visible)
				{
					double φ = Vector3d.Angle(vs.normal, viewDirection);
					if (φ < α)
					{
						visibleSurfaces++;
						vs.visible = true;
					}
				}
			}
			return visibleSurfaces;
		}
	}
}
