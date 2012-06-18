
    function checkAll(obj, grvID,ckID) {       
        if (obj.checked) markAllState = true;
        else markAllState = false;
        frm = document.forms[0];
        for (i = 0; i < frm.elements.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name != (grvID + '$ctl01$check') && (e.name.indexOf(ckID) > -1)) {
                temp = 'e.checked = ' + markAllState;
                eval(temp);
            }
        }
    }
