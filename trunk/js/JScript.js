function selectall(checkboxName)
{
	changeCheckboxState(checkboxName, true);
}//selectall


function deselectall(checkboxName)
{
	changeCheckboxState(checkboxName, false);
}//deselectall

function reverse(checkboxName)
{
	changeCheckboxState(checkboxName, null);
}
function confirmDelete(message)
{
	var a= confirm(message);
	if (a==true)
		return true;
	return false;	
}
//private functions
function changeCheckboxState(checkboxName, isChecked)
{
	//isChecked
	//=true --> select
	//=true --> desselect
	//=null --> reverse
	for(var i=0; i<document.forms[0].elements.length; i++)
		{
			var elm = document.forms[0].elements[i];
			if ((elm.type=="checkbox") && (elm.name.indexOf(checkboxName)>0))
				{
				    elm.checked = (isChecked!=null)?isChecked:(!elm.checked);					
				}
		}//for
}

//Insert and remove items between two listbox

function selectAll(obj){
    
        var objRight=document.getElementById(obj);
        
        for (var i=0; i<objRight.childNodes.length; i++)
        {
            //alert(objRight.childNodes[i].nodeName.toLowerCase());
            if (objRight.childNodes[i].nodeName.toLowerCase()=="option")
                objRight.childNodes[i].selected=true;
        }
        return false
    }
function insert(objSrc,objDes)
{   debugger
    var objLeft=document.getElementById(objSrc); 
    var objRight=document.getElementById(objDes);
    for (var i=objLeft.childNodes.length-1;i>=0; i--)
    {
        var objOption=objLeft.childNodes[i];
        if (objOption.selected)
        {
            var item2Move=objOption.cloneNode(true);
            objRight.appendChild(item2Move);
            objOption.removeNode(true);
        }
    }   
    return false
}
function remove(objSrc,objDes)
{
    var objLeft=document.getElementById(objSrc);
    var objRight=document.getElementById(objDes);
    for (var i=objRight.childNodes.length-1;i>=0; i--)
    {
        var objOption=objRight.childNodes[i];
        if (objOption.selected)
        {
            var item2Move=objOption.cloneNode(true);
            objLeft.appendChild(item2Move);
            objOption.removeNode(true);
        }
    }
    return false   
}
function insertAll(objSrc,objDes)
{
    var objLeft=document.getElementById(objSrc);
    var objRight=document.getElementById(objDes);          
    for (var i=objLeft.childNodes.length-1;i>=0; i--)
    {
        var objOption=objLeft.childNodes[i];                
        var item2Move;
        item2Move=objOption.cloneNode(true);     
        objRight.appendChild(item2Move);
        objOption.removeNode(true);           
    }   
    return false
}
function removeAll(objSrc,objDes)
{
   var objLeft=document.getElementById(objSrc);
    var objRight=document.getElementById(objDes);         
    for (var i=objRight.childNodes.length-1;i>=0; i--)
    {
        var objOption=objRight.childNodes[i];                
        var item2Move;
        item2Move=objOption.cloneNode(true);     
        objLeft.appendChild(item2Move);
        objOption.removeNode(true);           
    }   
    return false
}