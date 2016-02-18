﻿//Ví dụ với dữ liệu tĩnh

$(function () {
    var mapData = [
			        {
			            "name": "MienBac",
			            "path": "M163,-735,171,-733,177,-726C181,-723,178,-725,179,-718L189,-718,195,-719,198,-713,202,-711,205,-712,207,-710,208,-709,210,-707,210,-708,211,-709,212,-709,212,-711,212,-713,213,-718,213,-718,214,-718,214,-718,215,-720,215,-720,216,-720,216,-720,216,-721,217,-722,216,-722,216,-722,216,-723,215,-724,217,-723,217,-724,215,-726,215,-728,215,-729,214,-729,214,-730,215,-729,216,-731,217,-730,216,-733,217,-738,217,-741,217,-741,217,-741,217,-742,217,-742,216,-743,216,-743,216,-742,215,-742,215,-743,216,-743,217,-743,217,-742,217,-742,217,-744,217,-745,218,-746,219,-749,219,-750,220,-751,221,-751,222,-751,222,-751,222,-752,223,-754,223,-755,223,-754,221,-754,220,-754,220,-754,221,-755,222,-756,223,-756,223,-756,223,-755,224,-756,224,-758,224,-759,225,-761,225,-762,225,-763,225,-763,225,-764,226,-765,228,-768,229,-768,229,-769,230,-769,230,-769,231,-768,232,-767,233,-767,233,-768,234,-771,234,-772,234,-772,234,-770,234,-769,234,-768,234,-767,235,-768,237,-768,238,-769,238,-770,239,-772,240,-773,240,-772,240,-772,239,-770,240,-771,242,-773,243,-774,244,-776,246,-777,248,-780,248,-781,249,-782,250,-782,250,-783,250,-783,250,-784,251,-784,251,-784,251,-784,251,-784,251,-784,251,-783,255,-784,255,-784,257,-785,258,-785,259,-786,259,-787,260,-787,260,-788,260,-788,260,-788,260,-789,260,-789,258,-790,258,-790,258,-789,257,-790,257,-790,257,-790,258,-791,259,-790,260,-790,260,-789,261,-789,261,-790,261,-791,262,-792,262,-793,262,-794,260,-795,261,-795,261,-795,261,-795,261,-795,261,-795,261,-794,262,-795,262,-797,263,-800,262,-800,261,-800,259,-800,258,-799,258,-799,258,-800,259,-800,259,-801,259,-801,260,-801,261,-802,262,-802,262,-803,261,-804,261,-805,262,-806,262,-806,260,-805,259,-805,258,-806,262,-808,263,-809,264,-809,264,-810,264,-810,265,-810,264,-811,264,-811,264,-811,264,-812,263,-813,262,-813,262,-814,263,-814,264,-812,264,-812,265,-812,266,-812,267,-813,268,-813,269,-814,269,-815,268,-816,267,-816,267,-817,267,-817,269,-816,270,-816,270,-816,271,-817,271,-817,271,-817,272,-817,273,-818,273,-817,273,-817,274,-816,275,-815,274,-819,273,-820,273,-819,272,-820,271,-822,270,-823,270,-824,271,-823,272,-824,272,-825,271,-827C271,-828,270,-828,269,-828L269,-829,270,-831,271,-829C271,-830,272,-830,272,-831,272,-832,272,-832,272,-833L271,-833,271,-833C270,-834,269,-834,268,-834,267,-835,267,-836,267,-837,266,-837,266,-837,266,-838,267,-838,267,-837,268,-837L268,-838C267,-838,266,-838,265,-839L266,-839,268,-839,270,-838,270,-838C269,-838,269,-838,269,-839L271,-839,271,-839,272,-838,274,-838,274,-838C274,-839,273,-839,273,-839,274,-839,275,-839,275,-838L275,-837,275,-837,275,-837C276,-836,275,-836,275,-835L274,-835,273,-834,274,-833,275,-833,276,-833,277,-833C277,-833,277,-832,277,-832L278,-831,278,-830,279,-829,280,-831C279,-831,279,-832,279,-832,279,-832,279,-833,279,-833L279,-833C280,-832,280,-832,281,-831,281,-831,282,-831,283,-831,283,-831,282,-832,282,-832,282,-833,282,-833,281,-833L280,-834,279,-835,278,-837C278,-837,278,-836,279,-836L279,-837,280,-837,281,-835C282,-834,284,-834,285,-834,286,-834,287,-834,287,-834,288,-835,287,-835,288,-836L286,-838,286,-839,287,-838,288,-837,289,-837,288,-838,288,-838C289,-838,288,-839,288,-839L288,-839C288,-840,289,-839,289,-839L289,-838C289,-836,289,-839,289,-840L290,-840C289,-839,290,-838,290,-838L291,-838,291,-840,291,-839C292,-839,291,-839,291,-838L291,-838C291,-837,291,-838,292,-838L292,-838C292,-839,292,-839,292,-839,293,-839,293,-840,294,-840L294,-840,295,-840,295,-840,292,-837,290,-835,290,-834,291,-834,294,-833,295,-833,295,-833C296,-832,296,-833,297,-833L298,-833,298,-834,299,-836,300,-836,300,-836,299,-836C299,-836,299,-837,299,-837,300,-838,301,-837,303,-837,304,-838,305,-838,306,-838,307,-838,307,-838,308,-839,308,-840,308,-840,308,-840,307,-841,307,-841,307,-842L307,-843C307,-843,308,-843,308,-843,308,-844,308,-844,307,-844L308,-845,309,-847,309,-850C308,-849,308,-850,307,-850L307,-851,307,-854C308,-854,308,-854,308,-855,308,-855,308,-856,308,-856L309,-856,311,-856,312,-857,312,-857,311,-858,310,-859,311,-860,313,-859,313,-859C313,-858,314,-858,314,-858,315,-858,315,-858,316,-858,317,-857,317,-858,318,-858L317,-858C317,-859,317,-859,317,-859,317,-860,317,-860,317,-861L317,-861,318,-861,318,-860,318,-859C318,-859,319,-858,319,-858,319,-858,320,-858,320,-857,321,-857,321,-857,321,-858L322,-858,322,-860,323,-860C323,-860,323,-860,324,-860L324,-861C324,-861,324,-861,323,-861,323,-862,324,-862,324,-862,324,-862,324,-863,324,-863L324,-863,325,-863C326,-863,325,-864,325,-864,325,-865,325,-865,326,-865L326,-865C326,-865,327,-865,327,-864L328,-864,328,-865C329,-865,329,-865,329,-865L330,-865,331,-867C330,-867,331,-868,331,-868,332,-869,332,-868,332,-868,332,-869,332,-870,332,-870L333,-870,333,-871C332,-872,331,-872,330,-872L330,-872C331,-873,332,-873,332,-873L333,-873,333,-871,334,-872C333,-871,334,-871,334,-871,334,-872,334,-872,334,-873,334,-873,335,-873,335,-873,334,-872,335,-871,335,-871,336,-871,336,-872,337,-873L337,-873C337,-873,338,-872,338,-872,338,-873,338,-873,338,-874,339,-874,340,-875,339,-876L337,-877,336,-878,336,-879,336,-880,335,-881,334,-881,332,-882,331,-882,330,-882,329,-882,327,-880,326,-879,322,-879,321,-879,319,-879,318,-879,317,-878,317,-877,316,-877,316,-877,315,-877,314,-878,313,-878,313,-880,312,-881,311,-882,310,-881,309,-879,307,-878,306,-879,304,-884,302,-886,301,-886,299,-885,296,-886,292,-890,290,-892,288,-892,286,-893,286,-893,286,-895,286,-896,287,-897,288,-898,287,-900,287,-901,286,-901,285,-901,284,-901,283,-900,282,-900,280,-901,280,-902,279,-903,278,-903,277,-904,275,-904,273,-904,272,-905,272,-905,272,-906,271,-906,270,-906,270,-906,268,-904,267,-903,266,-903,266,-903,266,-904,266,-905,266,-905,267,-908,267,-910,267,-912,267,-912,266,-913,266,-913,266,-914,266,-915,266,-915,266,-916,266,-917,265,-918,265,-919,266,-920,266,-920,267,-921,265,-926,265,-927,264,-928,261,-928,260,-928,259,-929,259,-930,259,-933,259,-935,259,-936,259,-936,259,-937,260,-938,261,-945,261,-946,262,-947,263,-947,264,-947,265,-945,266,-945,267,-945,268,-945,269,-949,269,-950,270,-952,271,-953,271,-955,271,-957,272,-957,274,-959,274,-959,274,-960,273,-960,271,-960,270,-960,271,-961,270,-962,268,-964,267,-965,267,-965,266,-965,266,-965,265,-964,265,-964,263,-964,263,-965,262,-966,262,-967,261,-968,258,-968,257,-969,256,-969,256,-969,255,-967,254,-967,246,-964,245,-964,244,-964,243,-964,241,-965,241,-966,241,-968,240,-971,238,-972,235,-973,232,-973,228,-973,227,-972,226,-970,225,-970,224,-969,223,-969,222,-969,221,-969,220,-969,220,-969,220,-968,220,-968,219,-968,218,-969,215,-973,214,-974,214,-974,214,-974,213,-975,213,-975,212,-975,211,-976,210,-977,209,-977,208,-977,206,-978,202,-978,201,-978,201,-980,200,-981,200,-984,200,-985,199,-986,197,-988,196,-989,195,-991,195,-991,194,-993,194,-993,193,-994,193,-993,192,-993,192,-993,191,-994,190,-994,189,-995,188,-996,188,-998,188,-999,187,-1000,186,-1000,185,-999,183,-997,183,-996,182,-995,182,-994,182,-993,181,-992,180,-992,180,-992,179,-992,179,-992,179,-992,178,-993,178,-993,178,-993,178,-992,178,-992,177,-992,173,-990,172,-990,170,-989,168,-987,166,-985,165,-985,164,-985,163,-986,162,-986,161,-986,161,-985,161,-984,161,-983,159,-981,158,-981,157,-980,159,-971,159,-970,159,-969,156,-967,155,-966,153,-963,152,-962,151,-962,150,-961,149,-961,147,-962,146,-962,146,-962,145,-961,145,-961,144,-961,144,-961,144,-962,143,-962,143,-962,143,-963,143,-963,143,-963,143,-963,142,-962,138,-958,137,-957,131,-953,130,-953,129,-953,128,-954,125,-956,124,-957,124,-958,124,-959,124,-961,124,-962,123,-962,118,-960,116,-960,115,-960,115,-959,114,-959,114,-957,113,-957,112,-955,111,-953,111,-949,111,-948,110,-946,109,-945,109,-944,110,-943,109,-942,109,-941,108,-940,107,-941,107,-942,106,-942,105,-942,105,-944,104,-945,104,-945,103,-945,103,-945,101,-947,101,-947,100,-947,99,-949,99,-950,98,-951,94,-955,90,-960,90,-960,87,-959,86,-958,86,-957,86,-956,85,-955,84,-954,84,-953,84,-950,84,-949,82,-946,81,-945,80,-946,79,-946,78,-948,76,-952,75,-953,75,-954,75,-955,75,-956,74,-957,74,-958,73,-958,73,-959,72,-959,71,-960,70,-960,68,-955,66,-952,66,-951,65,-951,62,-949,60,-947,59,-945,59,-945,60,-944,60,-943,60,-942,57,-940,56,-940,55,-940,54,-939,54,-938,55,-937,54,-936,53,-935,52,-935,51,-936,49,-937,47,-938,46,-938,45,-939,43,-943,43,-945,43,-946,42,-947,41,-947,38,-948,37,-948,34,-952,32,-952,30,-953,29,-953,29,-953,28,-954,27,-955,27,-955,26,-954,26,-954,26,-953,24,-953,24,-954,24,-955,23,-957,22,-958,20,-958,19,-958,18,-957,18,-957,17,-954,17,-953,16,-952,16,-952,15,-952,14,-952,14,-952,14,-951,14,-950,15,-950,15,-949,15,-949,16,-949,15,-948,8,-940,7,-938,7,-936,7,-935,6,-934,5,-934,4,-934,3,-935,2,-934,1,-934,0,-933,0,-932,1,-931,1,-929,1,-929,2,-928,2,-928,2,-928,2,-927,2,-926,3,-925,4,-925,5,-924,5,-922,6,-921,10,-919,14,-915,16,-914,16,-913,17,-912,17,-911,18,-910,19,-909,20,-908,21,-907,21,-906,21,-906,21,-906,20,-905,20,-905,21,-903,23,-901,26,-900,28,-899,30,-894,30,-891,30,-887,30,-885,30,-884,31,-883,31,-882,31,-882,32,-882,35,-882,35,-882,37,-884,38,-886,39,-888,39,-893,40,-894,42,-893,42,-890,42,-887,42,-886,43,-885,44,-885,48,-887,48,-888,49,-888,49,-887,49,-886,49,-885,49,-880,50,-879,50,-877,50,-877,50,-877,50,-877,50,-876,49,-875,47,-872,46,-871,43,-866,44,-867,45,-868,46,-868,47,-868,47,-867,45,-864,45,-862,45,-859,44,-858,44,-857,42,-857,41,-856,40,-855,40,-854,42,-854,43,-854,44,-854,45,-853,45,-853,45,-852,45,-851,45,-850,45,-849,45,-849,46,-848,46,-848,47,-848,47,-847,48,-844,48,-843,49,-842,49,-842,49,-842,50,-842,52,-841,53,-840,54,-837,56,-833,57,-831,58,-828,59,-827,60,-827,60,-827,61,-827,62,-826,62,-826,63,-826,64,-825,65,-825,66,-826,66,-826,67,-825,70,-824,72,-823,73,-823,73,-823,75,-823,76,-824,76,-824,76,-825,77,-825,78,-825,78,-824,79,-822,80,-821,80,-820,81,-820,81,-820,82,-820,82,-820,82,-820,82,-820,86,-819,87,-818,89,-816,90,-814,90,-814,91,-814,91,-814,92,-814,93,-814,93,-815,94,-815,94,-815,93,-817,93,-817,93,-818,94,-819,94,-819,95,-819,96,-820,96,-820,96,-821,96,-822,96,-823,97,-825,97,-826,98,-827,98,-827,100,-827,100,-827,101,-827,102,-828,102,-828,106,-830,108,-830,108,-831,109,-831,111,-831,114,-834,116,-835,116,-834,117,-834,118,-833,118,-833,119,-833,120,-833,122,-832,122,-832,122,-832,123,-830,123,-830,124,-830,125,-830,126,-830,126,-830,127,-830,127,-829,128,-829,128,-828,129,-826,130,-825,131,-825,131,-824,132,-824,132,-823,133,-822,133,-822,134,-821,136,-821,137,-821,138,-820,138,-818,139,-817,142,-815,146,-814,146,-813,146,-811,142,-806,141,-805,139,-804,138,-804,136,-806,135,-803,135,-803,132,-800,131,-799,133,-798,136,-797,144,-797,145,-797,146,-795,147,-794,149,-793,150,-792,150,-792,151,-791,151,-790,151,-790,150,-789,150,-789,149,-789,149,-788,149,-787,149,-786,149,-785,149,-784,151,-783,153,-783,156,-784,158,-784,164,-781,164,-781,163,-780,163,-779,164,-777,166,-776,167,-775,167,-774,166,-774,166,-774,166,-774,166,-773,166,-772,166,-771,166,-770,166,-769,165,-768,164,-768,163,-768,162,-768,161,-768,161,-767,161,-766,159,-765,156,-763,155,-762,155,-760,155,-760,157,-760,158,-760,158,-759,158,-759,158,-757,158,-755,156,-754,155,-754,154,-752,152,-752,152,-752,151,-752,150,-751,149,-750,149,-749,147,-744,146,-743C148,-742,147,-744,150,-741L153,-739,157,-739,160,-737C162,-736,163,-731,163,-735zM277,-831,276,-831,274,-833,273,-831,273,-829,273,-828,274,-827,275,-827,275,-826C276,-827,275,-828,275,-828,278,-827,276,-831,277,-831zM273,-825,273,-824,274,-824,274,-824,275,-824,275,-825C275,-825,274,-825,274,-825L273,-827C272,-827,272,-826,272,-826zM269,-835C269,-836,269,-836,268,-836,268,-836,268,-836,268,-835,269,-834,269,-834,270,-834,271,-834,272,-834,272,-834,272,-834,272,-834,272,-834,273,-835,272,-835,272,-835,272,-836,272,-836,271,-837,271,-837,271,-837,270,-836,270,-836,271,-836,271,-835,270,-835,270,-835,269,-835zM283,-834,282,-833,283,-833,284,-833z"
			        },
			        {
			            "name": "MienNam",
			            "path": "M441,-289,441,-289C441,-290,442,-290,442,-290,442,-290,443,-290,443,-290,443,-291,444,-291,444,-292L445,-293,446,-293C446,-292,446,-293,447,-293L447,-294,447,-295,446,-296,444,-299,443,-301,441,-303,440,-305,439,-306,439,-306,439,-307,439,-308,438,-308,437,-309,437,-310,437,-311,438,-312,438,-313,437,-315,437,-315,438,-317,438,-317,438,-319,438,-319,438,-320,437,-320,437,-320,437,-320,437,-319,437,-319,437,-319,437,-318,437,-316,436,-317,435,-318,435,-320,435,-320,435,-320,435,-321,436,-321,436,-320,437,-320,437,-321,437,-321,437,-321,436,-322,436,-322,437,-322,437,-322,438,-323,437,-324,437,-324,436,-324,436,-324,435,-324,434,-326,433,-326,433,-327,433,-328,434,-328,433,-329,433,-330,433,-330,433,-331,433,-332,434,-332,434,-332,435,-332,437,-331,437,-331,437,-330,436,-329,436,-329,435,-329,436,-328,437,-328,437,-327,438,-328,438,-328,439,-329,439,-330,439,-331,439,-332,438,-331,438,-331,437,-332,437,-333,437,-333,438,-334,438,-335,437,-334,437,-334,437,-334,436,-334,435,-335,435,-336,435,-336,435,-336,435,-337,435,-337,434,-338,434,-338,433,-340,433,-340,433,-341,432,-341,432,-342,432,-343,432,-343,433,-342,434,-340,435,-338,436,-336,437,-335,437,-336,436,-336,436,-336,436,-337,437,-337,437,-337,437,-338,437,-338,437,-338,436,-339,435,-339,435,-340,435,-340,434,-341,434,-343,433,-344,433,-346,433,-346,433,-348,433,-349,433,-350,434,-351,435,-351,434,-351,433,-352,433,-353,432,-353,432,-354,433,-355,433,-357,433,-358,434,-359,435,-358,435,-354,435,-351,435,-350,437,-350,437,-350,437,-353,437,-358,437,-358,436,-360,435,-361,434,-368,433,-373,432,-374,430,-375,430,-376,430,-377,431,-377,432,-376,432,-375,432,-375,433,-375,431,-378,431,-380,431,-381,431,-384,431,-385,430,-386,428,-388,427,-390,427,-391,427,-392,427,-395,427,-396,426,-398,424,-404,424,-403,423,-402,423,-403,423,-403,424,-404,424,-404,424,-404,425,-404,425,-405,424,-406,424,-411,424,-410,425,-410,425,-410,424,-413,424,-414,422,-417,422,-417,420,-419,420,-420,419,-420,419,-421,420,-421,416,-430,415,-435C414,-437,415,-443,414,-439,413,-439,414,-440,413,-440,413,-441,413,-441,412,-441L411,-441C412,-442,412,-442,413,-442L414,-443C414,-445,414,-445,414,-446L414,-446,415,-446C415,-446,416,-447,416,-447L417,-448,416,-448C416,-448,415,-448,415,-448,414,-449,413,-450,413,-450L412,-451,413,-454,412,-454,411,-455C410,-455,410,-456,410,-456L410,-459C409,-459,409,-459,409,-459,409,-458,408,-458,407,-457L407,-456,407,-455,409,-455,409,-454C408,-454,408,-454,407,-454,407,-454,407,-453,407,-453L406,-453C406,-453,406,-454,407,-454L406,-455C406,-455,406,-456,406,-456L406,-457C405,-458,404,-458,404,-459,403,-459,403,-460,402,-461L402,-462,402,-464,401,-464,400,-461,399,-460,398,-461,397,-463C398,-464,398,-464,399,-464L400,-463,400,-464,401,-466,399,-465,397,-466,387,-481,386,-485,385,-489,385,-489,384,-490,384,-489,384,-489,383,-489,383,-489,383,-489,383,-489,384,-489,384,-491,383,-491,382,-492,379,-494,378,-495,377,-497C377,-497,377,-497,376,-498L375,-499,375,-499,373,-498,372,-498,373,-498,374,-499,374,-500,375,-501,375,-501,374,-503,374,-503,373,-503,372,-502,371,-503,370,-504,369,-505,369,-507,370,-509,372,-510,373,-512,371,-512,370,-512,368,-512,367,-513,367,-513,366,-512,365,-512,364,-513,363,-514,364,-515,365,-514,366,-513,364,-516,364,-518,363,-520,363,-520,363,-520,362,-519,362,-519,361,-518,360,-519,358,-521,357,-521,357,-520,357,-518,357,-518,355,-516,354,-516,354,-516,354,-516,353,-517,353,-517,352,-517,352,-517,350,-518,350,-518,349,-519,349,-522,349,-523,349,-523,350,-523,350,-522,351,-522,351,-522,351,-522,351,-522,350,-523,349,-525,348,-526,347,-528,346,-529,344,-530C344,-531,343,-531,343,-532L342,-531C342,-531,342,-531,342,-530L341,-530,341,-531C341,-531,340,-531,340,-532L340,-532C340,-533,341,-533,341,-533L341,-534,339,-533,339,-533,338,-533C338,-534,338,-534,338,-534L339,-534C339,-534,339,-534,339,-534L339,-534,338,-535,337,-536,337,-536,337,-536C336,-536,336,-536,335,-536L335,-537,334,-537,333,-537,331,-538,332,-539,337,-536C338,-536,333,-542,331,-543L324,-549,317,-556,316,-556,316,-556,315,-557,315,-557,314,-557,313,-556,313,-556,313,-556,313,-555,313,-555,312,-555,310,-555,310,-555,313,-557,313,-557,313,-557,313,-558,314,-558,314,-558,314,-559,313,-559,310,-564,309,-565,310,-568,309,-569,299,-577,288,-586,283,-592,282,-593,282,-594,282,-594,281,-595,281,-595,280,-596,280,-598,277,-603,275,-605,274,-608,273,-609,272,-610,270,-611,268,-611,267,-610,267,-610,267,-610,267,-609,266,-610,266,-611,267,-612,268,-612,269,-612,269,-612,266,-613,264,-613,262,-614,261,-614,260,-615,261,-615,261,-615,265,-615,268,-613,268,-613,269,-613,270,-611,272,-610,272,-610,273,-611,273,-611,271,-613,271,-613,271,-617,270,-619,269,-620,270,-621,270,-621,270,-622,269,-622,269,-622,270,-622,271,-623,271,-624,272,-625,273,-626,274,-626,274,-627,269,-634,269,-635,268,-636,269,-638,269,-638,268,-639,267,-637,267,-637,266,-637,266,-637,265,-637,265,-637,264,-636,264,-636,264,-635,264,-634,263,-635,263,-636,263,-637,263,-637,262,-637,262,-636,261,-637,262,-638,263,-638,263,-638,264,-638,264,-638,264,-639,263,-640,261,-642,259,-644,259,-644,258,-645,257,-645,254,-648,253,-648,252,-648,251,-647,250,-647,249,-647,250,-648,250,-649,249,-650,246,-652,244,-656,244,-656,242,-657,242,-658,241,-659,241,-660,241,-662,239,-662,236,-664,233,-670,232,-675,231,-675,231,-676,231,-678,231,-680,230,-681,230,-681,230,-677,230,-675,229,-675,229,-675,229,-677,229,-678,229,-679,228,-679,229,-682,229,-683,228,-684,227,-685,227,-686,226,-685,225,-686,225,-686,224,-687,225,-687,225,-687,226,-687,226,-686,227,-687,227,-687,226,-688,224,-689,224,-690C225,-693,224,-692,224,-692,224,-693,222,-695,222,-695L221,-697,221,-697,221,-698,220,-700,219,-702,218,-704,217,-706C212,-710,214,-707,212,-710,212,-710,212,-710,212,-710,211,-710,211,-709,211,-709,211,-709,211,-709,211,-709,210,-709,210,-710,209,-711,209,-711,208,-711,208,-711,208,-711,206,-713,206,-713,206,-713,203,-712,203,-712,203,-712,199,-715,199,-715,199,-715,196,-720,196,-720,196,-720,190,-719,190,-719,190,-719,180,-719,180,-719,180,-721,180,-723,180,-725,180,-725,180,-726,180,-726,180,-726,179,-727,179,-727,179,-727,179,-727,179,-727,179,-727,178,-727,178,-727,178,-728,175,-731,173,-733,173,-733,173,-733,173,-734,173,-734,172,-734,172,-734,172,-734,171,-734,170,-735,169,-735,168,-735,167,-735,167,-735,167,-735,166,-736,166,-736,165,-736,165,-736,165,-736,164,-736,164,-736,164,-736,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,164,-735,163,-735,163,-735,163,-736,163,-736,163,-736,163,-736,162,-737,162,-737,162,-737,162,-737,161,-738,161,-738,161,-738,160,-738,160,-739,160,-739,159,-739,159,-739,159,-740,159,-740,158,-740,158,-740,158,-740L154,-741,151,-742C150,-742,150,-743,149,-744L149,-744,148,-744,148,-744,146,-743,143,-741,142,-743,140,-744,140,-745,135,-744,134,-743,134,-743,133,-743,133,-742,133,-741,131,-741,130,-741,127,-743,127,-743,126,-743,126,-742,126,-741,127,-738,128,-737,130,-735,130,-735,131,-734,131,-733,131,-731,132,-731,132,-731,132,-731,132,-731,131,-730,131,-729,130,-729,130,-729,129,-728,129,-727,129,-726,128,-725,128,-725,128,-725,127,-725,126,-725,125,-724,123,-723,123,-723,122,-721,121,-720,119,-719,118,-719,117,-717,118,-717,119,-717,120,-717,121,-715,121,-715,121,-715,123,-714,125,-712,125,-712,126,-713,127,-713,128,-713,135,-709,137,-708,138,-707,138,-706,138,-705,139,-704,140,-705,141,-704,142,-703,143,-703,144,-702,145,-701,146,-701,147,-700,148,-699,150,-697,150,-696,151,-696,153,-696,154,-696,155,-695,156,-694,158,-691,159,-690,161,-689,162,-688,163,-687,164,-686,165,-686,166,-686,166,-685,167,-685,167,-684,168,-684,169,-683,171,-683,173,-682,174,-682,177,-682,179,-682,179,-680,180,-679,181,-679,182,-679,183,-679,184,-679,187,-677,189,-677,189,-677,190,-677,191,-677,191,-677,193,-674,194,-673,195,-672,195,-671,194,-670,194,-670,193,-670,192,-670,191,-669,191,-667,190,-663,190,-661,190,-659,192,-657,193,-656,194,-655,194,-654,194,-653,194,-652,195,-651,197,-649,198,-648,198,-647,199,-647,199,-647,201,-647,202,-647,202,-647,202,-646,202,-646,202,-644,202,-643,203,-642,204,-642,205,-641,206,-641,206,-641,206,-640,206,-640,207,-641,207,-641,207,-643,208,-643,209,-644,210,-644,211,-643,212,-642,213,-642,213,-640,213,-639,213,-639,213,-639,213,-639,213,-638,214,-638,214,-638,215,-636,215,-635,216,-635,217,-634,217,-633,217,-632,218,-631,218,-631,219,-630,219,-630,220,-628,220,-623,220,-620,223,-618,224,-615,225,-613,226,-612,227,-609,227,-608,228,-608,231,-606,233,-605,234,-603,238,-598,239,-597,240,-597,245,-590,254,-581,256,-580,256,-580,257,-580,258,-581,258,-582,258,-582,259,-583,259,-583,260,-583,260,-582,260,-581,260,-580,261,-580,261,-579,262,-579,262,-578,261,-577,261,-576,261,-575,263,-572,266,-569,267,-568,267,-568,266,-567,266,-567,267,-564,268,-563,268,-563,268,-563,269,-562,270,-562,271,-562,273,-561,274,-563,275,-562,275,-543,275,-541,276,-540,277,-538,278,-537,279,-537,280,-537,281,-536,281,-535,281,-532,281,-531,282,-529,283,-527,284,-526,286,-526,286,-525,286,-525,286,-525,287,-525,288,-526,288,-526,288,-527,288,-527,290,-528,290,-529,290,-530,292,-532,293,-532,294,-531,294,-528,294,-526,294,-526,294,-525,294,-525,294,-525,294,-525,294,-525,295,-525,295,-525,296,-523,296,-522,297,-521,299,-521,299,-520,299,-520,299,-518,300,-518,300,-517,301,-517,303,-517,305,-517,306,-517,307,-516,308,-515,309,-514,310,-511,310,-510,310,-509,311,-508,312,-508,313,-507,314,-507,315,-507,316,-506,318,-503,320,-502,321,-501,323,-501,326,-502,327,-502,328,-502,328,-501,327,-500,328,-499,328,-499,328,-498,327,-497,327,-496,325,-493,324,-492,323,-492,321,-491,320,-491,316,-488,315,-488,315,-488,314,-488,314,-488,313,-488,312,-487,311,-484,311,-482,312,-481,315,-479,315,-479,316,-478,316,-475,316,-474,317,-473,318,-472,320,-471,321,-470,324,-464,325,-464,325,-464,325,-464,326,-465,326,-465,327,-465,328,-465,328,-465,328,-465,329,-464,329,-464,329,-464,329,-463,329,-463,330,-464,331,-463,331,-462,331,-460,331,-459,332,-458,335,-459,336,-459,336,-458,336,-455,337,-454,337,-453,340,-451,341,-450,341,-449,341,-448,341,-445,340,-445,340,-444,340,-445,339,-445,339,-444,339,-444,339,-442,338,-440,338,-439,337,-439,336,-438,336,-438,336,-437,337,-436,337,-435,336,-435,335,-434,334,-435,333,-435,330,-434,329,-434,328,-433,328,-432,329,-431,328,-430,329,-429,329,-429,330,-428,331,-428,334,-425,335,-424,335,-423,334,-422,331,-419,331,-419,331,-418,332,-417,332,-416,331,-415,332,-414,332,-414,333,-413,333,-412,333,-410,333,-409,332,-405,332,-404,332,-402,332,-401,331,-401,331,-399,330,-398,330,-398,330,-397,329,-395,329,-394,328,-394,327,-393,327,-394,326,-394,326,-394,325,-394,325,-394,325,-393,325,-392,324,-392,323,-389,323,-388,323,-387,323,-386,323,-385,323,-384,323,-384,323,-381,321,-375,321,-374,321,-373,322,-372,322,-371,322,-370,322,-369,322,-367,323,-366,324,-366,326,-366,327,-365,327,-365,327,-364,327,-364,327,-363,328,-361,328,-360,328,-359,328,-358,328,-357,328,-355,328,-355,328,-353,328,-353,328,-352,329,-350,330,-349,330,-349,331,-347,332,-346,337,-335,338,-333,338,-327,338,-325,329,-302,329,-301,330,-300,330,-300,330,-299,330,-299,330,-299,330,-298,329,-297,330,-297,330,-295,330,-293,331,-292,331,-291,333,-289,334,-288,334,-286,334,-284,334,-282,335,-275,335,-273,335,-271,335,-270,334,-269,334,-269,335,-268,335,-266,333,-261,333,-259,332,-258,331,-257,330,-256,328,-255,327,-252,325,-252,324,-253,322,-256,321,-257,318,-257,315,-255,311,-254,309,-252,309,-251,308,-250,307,-249,305,-246,301,-242,299,-241,297,-240,295,-240,291,-240,289,-240,287,-239,286,-237,286,-235,285,-234,283,-233,280,-234,281,-233,276,-234,273,-234,271,-232,270,-232,270,-233,270,-233,269,-234,269,-234,268,-234,267,-234,267,-232,269,-228,269,-227,269,-227,268,-225,268,-225,268,-223,268,-223,268,-222,267,-221,267,-220,267,-219,268,-216,269,-215,268,-214,268,-214,267,-214,266,-215,265,-215,264,-215,264,-215,260,-214,260,-215,259,-215,258,-216,258,-217,257,-218,253,-219,250,-219,247,-220,244,-221,243,-219,243,-218,243,-217,242,-216,241,-215,240,-213,240,-212,238,-212,235,-214,234,-213,233,-212,232,-211,231,-210,231,-209,232,-207,233,-207,234,-207,235,-206,235,-205,235,-205,235,-203,236,-199,236,-198,236,-197,235,-195,234,-190,234,-189,235,-189,248,-189,255,-191,260,-189,263,-186,265,-183,268,-180,271,-178,272,-170C273,-170,274,-167,274,-167,277,-165,280,-161,283,-157,283,-157,285,-156,285,-156,286,-155,288,-152,289,-151,290,-151,294,-148,295,-148L299,-145C299,-144,299,-143,298,-142,299,-140,299,-140,300,-139,300,-139,300,-138,300,-138,300,-137,300,-137,300,-137,301,-136,301,-138,302,-139,303,-140,303,-139,302,-141,301,-142,301,-143,301,-145,301,-146,302,-147,302,-147L303,-148C302,-149,302,-150,301,-150L301,-151,303,-150,304,-148,304,-147C302,-148,303,-146,304,-146,304,-144,304,-142,304,-140,304,-139,303,-139,303,-139,303,-139,302,-138,302,-138L302,-137C302,-138,303,-138,304,-138,304,-138,304,-137,304,-137,305,-137,305,-138,306,-139L306,-138C306,-138,306,-137,306,-137,306,-137,306,-138,307,-138,308,-138,309,-138,309,-137,309,-136,310,-136,310,-136L310,-137C311,-137,312,-137,312,-137L312,-137C313,-136,313,-136,314,-135,314,-135,315,-135,315,-134,315,-133,314,-133,314,-133L313,-132,315,-132,317,-131,318,-131,320,-133C320,-134,321,-135,322,-135L322,-135,325,-136C327,-136,330,-137,332,-138L333,-139C334,-140,334,-140,334,-141L336,-142,336,-143,339,-144,340,-145,341,-145,345,-147,347,-148,348,-149,350,-151,354,-152,355,-153,356,-153,357,-153,360,-152,360,-151,361,-151,363,-156,363,-159,364,-160,364,-161,365,-162,366,-164,366,-164,367,-165,369,-166,376,-168,378,-167,378,-165,378,-165,379,-167,380,-168,381,-168,381,-168,382,-171,382,-172,383,-172,384,-172,384,-173,387,-174,387,-174,388,-174,389,-175,390,-177,390,-179,391,-180,392,-181,394,-181,394,-182,395,-182,397,-182,398,-182,399,-183,399,-183,400,-183,401,-182,402,-182,403,-182,404,-182,404,-183,405,-184,405,-187,406,-189,406,-189,407,-190,409,-192,410,-192,411,-192,412,-192,413,-192,416,-191,417,-191,417,-191,418,-192,420,-193,420,-194,421,-194,421,-197,421,-201,421,-204,420,-206,421,-206,422,-206,421,-207,421,-208,422,-209,422,-210C421,-210,421,-210,421,-211L421,-212,422,-212,422,-212,423,-209,423,-209C424,-208,425,-208,425,-208L426,-208C426,-208,427,-208,427,-208L428,-209,428,-209C428,-210,429,-210,429,-211,429,-211,430,-212,430,-212L430,-213C430,-213,431,-214,431,-214L432,-216C432,-216,432,-217,433,-217L433,-217,434,-218,431,-222,431,-223,431,-224C431,-225,431,-225,431,-226L431,-227,431,-227,430,-226C430,-225,429,-225,429,-224L427,-224,427,-227,427,-229,429,-229,430,-230,431,-232,432,-234,432,-236,431,-237,430,-238,430,-239,430,-241C430,-241,430,-241,430,-241L429,-243,430,-244,430,-243C431,-243,431,-243,432,-243L432,-243,432,-244,433,-244C432,-245,432,-246,432,-248L431,-248,431,-249,431,-249,430,-248,430,-249,431,-249,433,-249,432,-249,432,-250,431,-251,432,-252,431,-252C430,-253,430,-253,430,-253L430,-253,431,-253,432,-254,432,-255C433,-255,433,-255,433,-254L434,-255C434,-256,433,-256,432,-256L432,-257,432,-258,432,-259,432,-261,431,-262,430,-261,429,-262,428,-263,428,-264,429,-264,429,-264,429,-264,429,-264,429,-265,429,-265,430,-265,432,-264,435,-261,435,-259C436,-259,436,-259,437,-258L438,-259C438,-260,438,-260,438,-261L439,-260C440,-260,439,-260,439,-261L440,-261,439,-262,438,-263C438,-263,437,-263,437,-263,437,-264,437,-264,437,-265L437,-266,437,-267,434,-269,433,-269,433,-271C433,-271,434,-272,434,-273L434,-274,433,-274,433,-273C434,-274,433,-273,433,-273L433,-273C433,-272,432,-272,432,-271L432,-271,432,-271C431,-273,432,-272,431,-272,431,-273,431,-273,431,-274L432,-274,431,-277,431,-278,433,-280C433,-281,434,-281,434,-281L435,-282,437,-284,437,-284,439,-286,440,-286C439,-287,440,-287,440,-287L441,-287C441,-288,441,-287,441,-289zM440,-340,440,-340,440,-340,441,-340,441,-340,441,-341,440,-341,440,-342,440,-342,440,-341z"
			        },
			        {
			            "name": "MienTrung",
			            "path": "M249,-191,236,-191,236,-190,236,-189,236,-185,237,-184,236,-183,236,-181,235,-176,235,-175,236,-175,237,-174,237,-174,237,-172,237,-172,238,-171,239,-170,242,-169,243,-168,245,-166,246,-164,248,-163,248,-161,249,-160,250,-162,251,-162,252,-162,253,-161,253,-160,254,-156,255,-155,255,-155,253,-155,252,-155,251,-154,251,-154,251,-153,251,-152,251,-152,251,-151,253,-148,254,-141,253,-143,251,-143,248,-143,247,-144,245,-145,244,-146,242,-147,242,-148,240,-150,240,-149,239,-147,239,-146,238,-145,237,-145,236,-146,235,-147,235,-148,234,-150,233,-151,231,-154,230,-156,229,-158,228,-158,226,-157,225,-156,225,-156,224,-155,222,-155,213,-153,213,-153,211,-153,210,-154,209,-154,209,-154,206,-151,205,-147,204,-146,203,-146,201,-148,200,-149,192,-151,191,-151,190,-152,190,-153,190,-153,189,-152,188,-152,187,-151,186,-150,186,-149,186,-147,187,-144,189,-140,189,-138,188,-137,182,-133,181,-133,181,-132,178,-128,177,-126,175,-125,172,-125,163,-126,161,-126,160,-126,159,-125,159,-124,158,-123,156,-120,155,-119,154,-119,153,-119,153,-118,153,-117,153,-116,154,-116,155,-117,156,-117,157,-118,157,-119,157,-119,158,-118,158,-118,157,-117,157,-116,157,-116,156,-116,156,-116,156,-115,158,-113,158,-112,158,-110,159,-110,159,-110,159,-111,159,-111,161,-110,161,-109,161,-107,161,-105,162,-105,162,-104,163,-103,163,-103,162,-102,162,-102,163,-101,163,-101,165,-101,165,-102,165,-103,166,-103,166,-103,166,-104,166,-104,167,-105,168,-106,170,-107,172,-107,174,-105,175,-104,176,-101,178,-99,180,-98,181,-98,183,-99,184,-99,186,-98,188,-95,190,-92,191,-90,192,-89,192,-86,192,-84,192,-83,191,-87,190,-88,190,-88,189,-88,185,-85,184,-84,184,-82,183,-82,180,-81,179,-79,178,-76,176,-63,176,-61,176,-52,175,-49,175,-40,174,-36,174,-29,175,-27,176,-26,176,-26,174,-25,174,-23,175,-20,175,-19,174,-16,174,-15,175,-13,177,-13,181,-15,180,-14,181,-13,181,-12,181,-11,180,-11,180,-10,178,-10,177,-10,177,-10,176,-10,177,-9,178,-8,180,-8,182,-9,183,-10,183,-9,182,-8,181,-8,180,-7,176,-8,176,-8,175,-8,175,-7,176,-7,176,-6,176,-6,175,-5,175,-5,174,-5,171,-2,170,-3,169,-3,169,-3,169,-2,169,-2,171,-1,174,-1,175,0,175,0,176,0,177,0,190,-2,192,-3,194,-5,195,-8,199,-11,199,-12,201,-11,203,-13,204,-15,205,-16,209,-26,209,-27,209,-27,209,-28,210,-28,210,-28,210,-28,211,-29,211,-30,213,-32,215,-35,217,-36,230,-41,245,-48,253,-51,255,-51,255,-51,256,-52,255,-53,255,-54,254,-54,254,-54,256,-57,256,-58,256,-60,256,-61,256,-62,249,-72,249,-73,249,-75,248,-76C246,-78,249,-78,259,-68L264,-65,267,-63,267,-62,270,-62C270,-63,271,-63,271,-63,272,-63,272,-63,272,-63L273,-63C274,-63,275,-64,276,-65,278,-67,278,-70,278,-73L278,-74,278,-75,280,-77C279,-77,282,-80,281,-81L283,-82,283,-84,283,-84,283,-84,284,-83,284,-83,283,-82,283,-82,284,-83,285,-84,285,-85,284,-86,283,-86,280,-88,277,-91,272,-93,271,-94,266,-102,265,-103,264,-106,264,-107,262,-108,262,-108,261,-108,261,-109,263,-108,265,-106,270,-98,271,-96,273,-94,276,-93,277,-92,278,-91,279,-91,280,-90,282,-90,282,-90,282,-90,282,-91,283,-92,283,-92,283,-92,284,-92,284,-93,284,-93,283,-94,283,-94,283,-95,284,-95,284,-96,285,-96,285,-97,285,-97,286,-97,286,-96,286,-96,285,-95,286,-95,287,-95,290,-99,291,-100,291,-101,291,-102,290,-102,290,-103,289,-103,289,-103,288,-103,288,-103,288,-103,287,-104,287,-105,286,-105,272,-110,269,-112C269,-113,270,-112,270,-112,271,-112,272,-112,273,-111L275,-111,279,-111,285,-111,288,-110C289,-109,290,-110,290,-110L291,-112,290,-117C290,-118,289,-119,289,-119,288,-120,288,-121,287,-122L286,-123,286,-122C286,-121,285,-121,284,-120L283,-120C283,-120,283,-121,283,-122,283,-122,282,-122,282,-123,281,-121,280,-120,279,-120L278,-120C278,-121,278,-122,278,-123L278,-123C279,-122,279,-122,279,-121,278,-120,279,-121,280,-121,281,-121,282,-123,283,-124,284,-124,283,-125,282,-126L283,-126C283,-124,284,-125,284,-124,287,-125,287,-127,288,-129,289,-130,289,-130,289,-131,289,-133,288,-133,287,-134,287,-135,288,-136,289,-136,289,-136,290,-136,290,-136,291,-135,291,-135,292,-134,292,-133,292,-133,293,-133,294,-133,295,-133,296,-134,300,-134,295,-143,295,-142,296,-142,296,-144,299,-147,299,-147,296,-150,296,-150,296,-150,296,-150,296,-150,296,-150,295,-150,295,-150,295,-151,293,-152,293,-152,293,-152,290,-153,290,-153,290,-153,289,-153,289,-153,289,-154,288,-155,288,-155,288,-155,287,-156,287,-156,287,-156,286,-157,286,-157,286,-157,286,-158,286,-158,286,-158,286,-158,286,-158,286,-158,285,-158,285,-158,285,-158,285,-159,285,-159,285,-159,283,-159,283,-159,283,-159,282,-160,283,-160,283,-160,280,-163,280,-163,281,-163,280,-164,280,-164,280,-164,279,-165,279,-165,279,-165,278,-166,278,-166,278,-166,278,-167,278,-167,278,-167,277,-167,277,-167,277,-167,277,-168,277,-168,271,-168,276,-168,276,-168,276,-168,276,-168,276,-168,276,-168,276,-169,276,-169,276,-169,275,-169,275,-169,275,-169,275,-169,275,-169,275,-169,274,-171,273,-172,273,-172,272,-173,272,-173,272,-173,271,-180,271,-180,271,-180,270,-182,268,-183,267,-184,265,-186,265,-186,265,-186,264,-188,264,-188,264,-188,261,-191,261,-191,261,-191,256,-194,256,-194zM291,-133C291,-134,290,-134,289,-135L288,-135,290,-132C290,-131,290,-130,290,-129,288,-129,289,-128,288,-127,289,-127,288,-126,288,-125L288,-124C288,-122,290,-122,290,-120L293,-121,297,-124C299,-132,296,-131,291,-133z"
			        },
                    {
                        "name": "HoangSa",
                        "path": "M469,-579,471,-580,472,-581,473,-582,474,-584,475,-587,476,-591,477,-592,476,-593,475,-593,474,-591,474,-593,473,-591,473,-590,472,-591,471,-591,470,-588,470,-586,470,-585,468,-583,466,-581,463,-580,460,-578,460,-578,462,-578,467,-579zM456,-571,455,-572,455,-572,455,-570,456,-569,457,-568,458,-568,458,-568,459,-567,459,-567,459,-569,459,-569,458,-570zM460,-575,460,-575,460,-575,460,-576,460,-576,459,-577,457,-577,456,-577,456,-577,455,-577,455,-577,454,-577,454,-576,454,-576,455,-575,455,-576,456,-574,457,-574,458,-574,458,-574,460,-574zM504,-588,505,-590,506,-591,507,-592,505,-593,503,-591,503,-589,503,-588zM480,-590,480,-593,484,-601,484,-601,484,-602,483,-601,481,-599,480,-598,480,-598,480,-597,480,-594,479,-593,478,-592,478,-591,478,-589,478,-588,478,-588,477,-587,479,-587zM499,-588,500,-587,500,-588,497,-591,495,-591,495,-589,495,-588,496,-588,497,-587,497,-586,495,-582,497,-583,498,-584,499,-586,498,-588,499,-588zM475,-580,476,-582,477,-584,477,-585,476,-585,476,-586,476,-584,473,-579,472,-578,471,-577,470,-576,468,-576,468,-576,469,-574,469,-573,467,-569,469,-569,469,-570,470,-572,471,-573zM461,-568,461,-567,461,-566,461,-565,461,-565,462,-565,462,-564,462,-564,462,-565,463,-565,463,-566,462,-567,462,-568zM440,-576,440,-576,440,-576,441,-575,441,-575,441,-575,441,-574,442,-574,442,-575,442,-576,441,-576zM456,-581,456,-581,457,-581,459,-583,460,-584,460,-584,459,-585,459,-584,459,-584,459,-584,459,-584,458,-584,457,-583,456,-583,456,-582,455,-582,455,-582,455,-583,454,-583,453,-582,452,-582,452,-582,453,-581zM464,-581,464,-581,465,-583,466,-585,466,-585,465,-584,464,-583,463,-583,463,-583,463,-582,462,-581,461,-580,458,-579,456,-579,456,-578,459,-578,463,-580zM477,-597,477,-598,478,-598,479,-600,479,-601,479,-601,478,-601,477,-601,477,-601,477,-601,477,-601,476,-601,475,-599,475,-599,475,-598,474,-598,474,-598,474,-597,474,-597,475,-596,475,-596,474,-596,474,-596,474,-596,474,-596,473,-595,472,-594,471,-594,470,-593,471,-593,471,-593,472,-593,473,-594,474,-594,474,-595,476,-596,477,-597zM488,-610,487,-605,487,-604,487,-604,489,-611,489,-611,488,-611zM468,-560,468,-560,468,-561,468,-560,467,-560,467,-560,466,-558,467,-559zM469,-564,469,-564,468,-563,469,-563,470,-563,470,-565,470,-565zM448,-571,448,-571,448,-571,448,-571,448,-571,449,-571,449,-572,450,-572,451,-572,450,-572,450,-573,450,-573,450,-573,449,-573,449,-573,449,-572,449,-572,448,-572,448,-572,448,-572,449,-572,448,-572zM452,-576,452,-576,453,-575,452,-577,451,-578,450,-579,450,-579,451,-578zM453,-576,453,-577,453,-578,452,-579,452,-579,452,-579,452,-579,452,-577,453,-576zM477,-603,477,-603,477,-602,477,-602,477,-601,477,-601,479,-603,479,-603,478,-603,478,-603z"
                    },
                    {
                        "name": "TruongSa",
                        "path": "M531,-249,532,-249,533,-250,534,-251,534,-252,535,-255,536,-258,537,-259,536,-259,536,-259,535,-258,535,-259,534,-258,534,-257,533,-257,532,-258,532,-255,531,-254,531,-253,530,-252,528,-250,526,-249,524,-248,524,-247,525,-248,529,-249zM521,-242,520,-243,520,-243,520,-242,521,-240,521,-240,522,-240,522,-240,523,-239,523,-239,523,-241,523,-241,522,-242zM524,-245,524,-245,524,-246,524,-246,524,-246,523,-247,522,-247,521,-247,521,-247,520,-247,520,-247,519,-247,519,-246,519,-246,520,-246,520,-246,521,-245,521,-244,522,-244,522,-244,523,-245zM557,-255,559,-257,559,-258,559,-259,558,-259,557,-258,556,-256,556,-255zM539,-257,539,-259,542,-265,542,-266,542,-266,541,-265,540,-264,539,-263,539,-263,539,-262,539,-260,539,-259,537,-258,537,-257,537,-256,538,-256,537,-255,537,-255,538,-254zM554,-255,555,-255,555,-255,552,-257,551,-258,550,-256,551,-255,552,-255,552,-254,552,-254,550,-251,552,-251,553,-252,553,-254,553,-255,554,-255zM536,-249,536,-251,537,-252,537,-253,536,-253,536,-254,536,-252,534,-249,533,-247,533,-247,531,-246,530,-246,530,-246,531,-245,531,-244,529,-241,530,-241,531,-241,531,-243,532,-244zM525,-240,525,-239,525,-239,525,-238,525,-238,525,-237,525,-237,525,-237,526,-237,526,-238,526,-238,526,-239,525,-240zM509,-246,508,-246,508,-246,509,-245,509,-245,509,-245,510,-245,510,-245,510,-245,510,-246,509,-246zM520,-250,521,-250,522,-250,523,-252,524,-252,524,-253,523,-253,523,-253,523,-252,523,-252,523,-252,523,-252,522,-251,521,-251,521,-251,520,-251,520,-251,520,-251,519,-251,519,-251,518,-251,518,-251,519,-250zM527,-250,527,-250,528,-251,529,-253,528,-253,527,-252,527,-252,526,-251,526,-251,526,-250,525,-250,525,-249,522,-248,521,-248,521,-248,523,-248,526,-249zM537,-262,537,-263,538,-263,538,-264,538,-265,538,-265,538,-265,537,-265,537,-265,537,-265,536,-265,536,-265,536,-264,535,-264,535,-263,535,-263,535,-263,534,-262,534,-262,535,-262,535,-261,535,-261,535,-261,535,-262,534,-262,534,-261,533,-260,533,-260,532,-259,532,-259,533,-259,533,-259,533,-260,535,-260,535,-261,536,-261,537,-262zM545,-272,544,-268,544,-267,545,-268,546,-273,546,-273,545,-273zM530,-234,530,-234,530,-234,530,-234,529,-234,529,-234,528,-233,529,-233zM531,-237,531,-237,530,-236,531,-236,531,-237,532,-238,531,-237zM515,-243,515,-243,515,-242,515,-242,515,-242,516,-242,516,-243,516,-243,517,-243,516,-243,516,-243,516,-244,516,-244,516,-244,515,-244,516,-243,515,-243,515,-243,514,-243,515,-243,515,-243,515,-243zM517,-246,518,-246,519,-245,518,-247,517,-248,516,-248,516,-248,517,-247zM519,-246,518,-247,518,-248,518,-249,518,-248,517,-248,518,-248,518,-247,519,-246zM537,-267,537,-267,537,-266,537,-266,537,-265,537,-265,538,-266,538,-267,538,-267,538,-267z"
                    }
		        ];

    var data = [{
        "name": "MienBac",
        "fullName": "Miền Bắc",
        "eee": 541,
        "fff": 40120
    }, {
        "name": "MienTrung",
        "fullName": "Miền Trung",
        "eee": 111.8,
        "fff": 4115
    }, {
        "name": "MienNam",
        "fullName": "Miền Nam",
        "eee": 11.8,
        "fff": 17965
    },
     {
         "name": "HoangSa",
         "fullName": "Q.đảo Hoàng Sa"
     },
      {
          "name": "TruongSa",
          "fullName": "Q.đảo Trường Sa"
      }
    ];
    // Initiate the chart
    $('#dvMap').highcharts('Map', {

        chart: {
            height: 562,
            type: 'line'
        },
        title: {
            text: 'Tỷ trọng'
        },
        series: [
        {   
            "type": "map",
            "data": data,
            "mapData": mapData,
            "joinBy": ['name', 'name'],
            tooltip: {
                pointFormat: '{point.fullName} <br/>Thông số 1: {point.eee}  <br/>  Thông số 2: {point.fff}'
            },
            name: 'Dữ liệu',
            credits: {enabled: false}
        }]
    });
});
//---------------------------------------------------------------------------------------------------------