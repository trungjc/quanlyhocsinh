function parseXML(vId)
{
try //Internet Explorer
  {
  xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
  }
catch(e)
  {
  try //Firefox, Mozilla, Opera, etc.
    {
    xmlDoc=document.implementation.createDocument("","",null);
    }
  catch(e)
    {
    alert(e.message);
    return;
    }
  }
var thamso,linktp;
thamso = document.form1.selectthanhpho.value;
if (thamso == 1) 
 {
   linktp = "http://vnexpress.net/ListFile/Weather/Danang.xml"
 }
else if (thamso == 2) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Haiphong.xml" }
else if (thamso == 3) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Nhatrang.xml" }  
else if (thamso == 4) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Pleicu.xml" }
else if (thamso == 5) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Sonla.xml" }
else if (thamso == 6) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Hanoi.xml" }
else if (thamso == 7) 
 { linktp = "http://vnexpress.net/ListFile/Weather/HCM.xml" }
else if (thamso == 8) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Vinh.xml" }
else if (thamso == 9) 
 { linktp = "http://vnexpress.net/ListFile/Weather/Viettri.xml" }      
xmlDoc.async=false;
xmlDoc.load(linktp);

document.getElementById("thongtintt").innerHTML=
xmlDoc.getElementsByTagName("Weather")[0].childNodes[0].nodeValue;
document.getElementById("images1").innerHTML="<img src='http://vnexpress.net/Images/Weather/" +
xmlDoc.getElementsByTagName("AdImg1")[0].childNodes[0].nodeValue+"'>";
document.getElementById("images2").innerHTML="<img src='http://vnexpress.net/Images/Weather/" +
xmlDoc.getElementsByTagName("AdImg2")[0].childNodes[0].nodeValue+"'>";
document.getElementById("images").innerHTML="<img src='http://vnexpress.net/Images/Weather/" +
xmlDoc.getElementsByTagName("AdImg")[0].childNodes[0].nodeValue+"'>";
}