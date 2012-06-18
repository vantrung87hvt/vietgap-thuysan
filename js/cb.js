function INVICheck(cbID)
{
    this.CheckAll=function()
    {
        var eInput=document.getElementsByTagName("input");
        for(i=0;i<eInput.length;i++)
        {
            if(eInput[i].type=="checkbox" && eInput[i].id.match(cbID))
                eInput[i].checked=true;
        }
    }
    this.UnCheckAll=function()
    {
        var eInput=document.getElementsByTagName("input");
        for(i=0;i<eInput.length;i++)
        {
            if(eInput[i].type=="checkbox" && eInput[i].id.match(cbID))
                eInput[i].checked=false;
        }
    }
}
var inviCheck=new INVICheck("chkDelete");
