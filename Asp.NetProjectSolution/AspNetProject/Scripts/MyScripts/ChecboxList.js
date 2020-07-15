$(function () {

    $("#SelectALL").change(function () {
        
        if (this.checked) {

            selectAll();
        }
        else {
            selectNone();
        }

    });

    function selectAll() {        
        
        $("#CheckBoxList :checkbox").each(function () {
            this.checked=true;
        });
    }

    function selectNone() {
        $("#CheckBoxList :checkbox").each(function () {
            this.checked = false;
        });
    }

    $("#Search").keyup(function () {
        
        Search(this.value, this);
       
    });

    function Search(SearchText, target)
    {       
        if (SearchText.trim().length == 0) {
            $("#CheckBoxList label").show();
        }
        else {
            $("#CheckBoxList label:contains('" + SearchText.trim() + "')").show();

            $("#CheckBoxList label:not(:contains('" + SearchText.trim() + "'))").hide();
        }      
    }

    $('#btnDrop').click(function () {

        if ($('#CheckBoxList').css("height") == '100px') {
            $('#CheckBoxList').css('height', '20px');
        }
        else {
            $('#CheckBoxList').css('height', '100px');
        }
    });

});