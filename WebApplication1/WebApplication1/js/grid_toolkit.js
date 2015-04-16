function setGrid(){
	fixHeader();
	setTable();
}
// window.onload =  new Function('fixHeader()');

window.onload= new Function('setGrid()');



//Function for Highlight the table row & Alternative Colors

var rhead=0;
function setTable()
{
    var oldClass;
    var oTable = document.getElementsByTagName('table');
      

    for(j=0;j<oTable.length;j++){
			if(oTable[j].className.indexOf('tableContainer')!=0){
        var tr=oTable[j].getElementsByTagName('tr');
        for(i=0;i<tr.length;i++){ 					
          var oTr=tr[i+rhead];
					if(i%2==0){
						tr[i].className="altRow"
					}
					if(oTr!=null){
						
						// For row highlight state use rowBackcolor class
							oTr.onmouseover=function(){
								oldClass=this.className; 
								this.className="rowHover";
							}
							
							// For row normal state row class
							oTr.onmouseout=function(){ this.className=oldClass;}
					}
        }
			}
    }
}




/* Function for Fix Header */

var fhDiv;           
var eDiv;
var fhDivContent;
var fhTable;
var newHeader;
var mainHeight,mainWidth; 
var tableWidth;

var cellWidth=150;
var boxHeight;

function fixHeader(){


    eDiv =  document.getElementsByTagName("div");

    for(var i=0;i<eDiv.length;i++){

			if (eDiv[i].className.indexOf("tableContainer")!=-1){
					fhDiv = eDiv[i];                            
		      fhDivContent = fhDiv.innerHTML;
          fhTable = fhDiv.getElementsByTagName("table");
					boxHeight=eDiv[i].offsetHeight;
					mainHeight = eDiv[i].offsetHeight;
					
					mainWidth = fhDiv.offsetWidth;
					tableWidth = fhTable[0].offsetWidth;

            if(fhTable.length>1){
               alert("Warning: You can't have 2 table under same fixed div");
            }else{       
               try{
                   alert(fhDiv.id);
										fhDivContent="<div  id='"+fhDiv.id+"_body' class='tableBody'><table width='auto' border='0' cellspacing='0' cellpadding='0'>"+fhTable[0].tBodies[0].innerHTML+"</table></div>";

										newHeader="<div id='"+fhDiv.id+"_header' class='tableHead' onscroll='syncScroll("+fhDiv.id+")' ><table width='auto' border='0' cellspacing='0' cellpadding='0'><thead><tr>" + fhTable[0].rows[0].innerHTML + "</tr></thead></table></div>";

										fhDiv.innerHTML=newHeader+fhDivContent;                                                                 

										var tBody=document.getElementById(fhDiv.id+"_body");
										var tHead=document.getElementById(fhDiv.id+"_header");
										
										var hTable = tHead.getElementsByTagName("table");							
										var bTable = tBody.getElementsByTagName("table");

										tHead.style.width = (mainWidth)-(18)+"px";
										tBody.style.width = (mainWidth)-(1)+"px";
										tBody.style.marginTop=tHead.offsetHeight+"px";
										
										var bodyHeight = (mainHeight)-(tHead.offsetHeight)-(2);
										
										tBody.onscroll= new Function('syncScroll(\''+ fhDiv.id +'\')');
										setInterval('timeScroll(\''+ fhDiv.id +'\')',100);
                 }

                 catch(err){
                    // do nothing
                 }           
           	}           
					 setColWidth(fhDiv.id);
					 setText(fhDiv.id);
					 setBoxHeight(fhDiv.id);

        }
  }
	
	
}


function setText(divName){
	
	$("#" + divName + " table td" ).each(function(){
		var html = $(this).html();

		$(this).html("<span></span>");		
	
		$("span", this).css({"width":+$(this).width()});
		$("span", this).html(html);
		
		$("span", this).each(function(){
			//alert($("span", this).innerWidth()+ " " +$("span", this).width());
			
			if(this.scrollWidth>this.offsetWidth){
				 $(this).hover(function(e){
					$("#tooltip").text($(this).text());
					if($("#tooltip").width>300){
						$("#tooltip").width("300px");
					}
					//$("#tooltip").css({"z-index":999999999999999});

					$("#tooltip").fadeIn("fast");
				 },function(){
 					$("#tooltip").fadeOut("fast");
					//$("#tooltip").empty(); 
				 });
				 
				 $(this).mousemove(function(e){$("#tooltip").css({"top":e.pageY+20,"left":e.pageX});})
			}
		});
		
	});
	
}

function setBoxHeight(divName){
	
		var mBox = document.getElementById(divName);
		if(mBox!=null){

				var tBody=document.getElementById(mBox.id+"_body");
				var tHead=document.getElementById(mBox.id+"_header");
				
				var hRows = tHead.getElementsByTagName("tr");
				var bRows = tBody.getElementsByTagName("tr");

				var hTable = tHead.getElementsByTagName("table");							
				var bTable = tBody.getElementsByTagName('table');
				
				
				
				var os=navigator.appName;

				if (os.indexOf("Microsoft Internet Explorer")!= -1){
					if((bTable[0].offsetHeight+1)==tBody.offsetHeight){
							tBody.style.height=tBody.offsetHeight+(17)+"px";
					}
				}
				
				var nBoxHeight = (tHead.offsetHeight+tBody.offsetHeight);
				
				if(nBoxHeight<boxHeight){
					mBox.style.height = nBoxHeight+1+"px";
					tBody.style.width = (tBody.offsetWidth)-1+"px";					
					rightCellAdjustment(divName);
				}else{
					tBody.style.height = boxHeight-(tHead.offsetHeight)+"px";
					mBox.style.height = boxHeight+1+"px";
				}
				
				mBox.style.width= mBox.offsetWidth-1+"px";
		}
}
function rightCellAdjustment(divName){
		var mBox = document.getElementById(divName);
		if(mBox!=null){

				var tBody=document.getElementById(mBox.id+"_body");
				var tHead=document.getElementById(mBox.id+"_header");
				
				tHead.style.borderRight="none";
				
				var os=navigator.appName;

				if (os.indexOf("Microsoft Internet Explorer")!= -1){
						tHead.style.width=tHead.offsetWidth+(16)+"px";
				}else{
						tHead.style.width=tHead.offsetWidth+(15)+"px";
				}
		}
}

function setColWidth(divName){

		var mBox = document.getElementById(divName);

		if(mBox!=null){

				var tBody=document.getElementById(mBox.id+"_body");
				var tHead=document.getElementById(mBox.id+"_header");
				
				var hRows = tHead.getElementsByTagName("tr");
				var bRows = tBody.getElementsByTagName("tr");

				var hTable = tHead.getElementsByTagName("table");							
				var bTable = tBody.getElementsByTagName('table');

			 	var os=navigator.platform;
				
				if (os.indexOf("Mac") != -1){
					ppConstent=3;
				}
				else{
					ppConstent=12;
				}

				var nTableWidth=(bRows[0].cells.length)*cellWidth+((bRows[0].cells.length)*2)-1;
				//alert(hTable[0].offsetWidth);
				//var nTableWidth = hTable[0].offsetWidth 	 //(hRows[0].cells.length)*cellWidth+((bRows[0].cells.length)*2)-1;
				
				hTable[0].style.width=nTableWidth+"px";
				bTable[0].style.width=nTableWidth+"px";
				
				for(j = 0 ; j < bRows[0].cells.length ; j++){		
						bRows[0].cells[j].style.width=hRows[0].cells[j].offsetWidth-(ppConstent)+"px"; //cellWidth-(ppConstent)+"px";
						//hRows[0].cells[j].style.width=cellWidth-(ppConstent)+"px";
				}

		}
}


function syncScroll(divName){
		var mBox = document.getElementById(divName);
		if(mBox!=null){

				var tBody=document.getElementById(mBox.id+"_body");
				var tHead=document.getElementById(mBox.id+"_header");
				
			if(tBody.scrollLeft>0){
				tHead.scrollLeft=tBody.scrollLeft;		
			}
		}
}
function timeScroll(divName){
		var mBox = document.getElementById(divName);
		if(mBox!=null){

				var tBody=document.getElementById(mBox.id+"_body");
				var tHead=document.getElementById(mBox.id+"_header");
				
			if(tBody.scrollLeft==0){
				tHead.scrollLeft=tBody.scrollLeft;		
			}
		}
}


