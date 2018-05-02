function ShowPassword() {
    var x = document.getElementById("psw");
    if (x.type == "password")
    {
        x.type = "text";
    }
    else
    {
        x.type = "password";
    }
}

$(document).ready(function ()
{
    $('#Comments').change(function ()
    {
        $('#Sub').toggle($(this).val() == 'Other');
    });
});

function ConfirmFn()
{
	var txt;
	if(confirm("You'r about to delete a Customer on the Waitlist\nare you SURE you want to do this?") == true)
	{
		txt="Contact Deleted!";
	}
	else
	{
		txt="You pressed Cancel!";
	}
	document.getElementById("Delete").innerHTML = txt;
}

function SearchCustomersFn()
{
	var input, filter, table, tr, td,i;
	input = document.getElementById("SearchCustomers");
	filter = input.value.toUpperCase();
	table = document.getElementById("ActiveRequests");
    tr = table.getElementsByTagName("tr");
	for (i = 0; i < tr.length; i++) 
	{
		td = tr[i].getElementsByTagName("td")[0];
		if (td) 
		{
			if (td.innerHTML.toUpperCase().indexOf(filter) > -1) 
			{
				tr[i].style.display = "";
			} 
			else 
			{
				tr[i].style.display = "none";
			}
		}     		
	}
}
function SearchCustomers2Fn()
{
    var input, filter, table, tr, td, i;
    input = document.getElementById("SearchCustomers");
    filter = input.value.toUpperCase();
    table = document.getElementById("ActiveRequests");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++)
    {
        td = tr[i].getElementsByTagName("td")[1];
        if (td)
        {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1)
            {
                tr[i].style.display = "";
            }
            else
            {
                tr[i].style.display = "none";
            }
        }
    }
}
//function SearchKIDStaff()
//{
//    //Declare variables
//    var input, filter, table, tr, td, i;
//    input = document.getElementById("SearchKIDStaff");
//    filter = input.value.toUpperCase();
//    table = document.getElementById("TableKIDStaff");
//    tr = table.getElementsByTagName("tr");
//    //loop through all table rows, and hid those who don't match teh search query
//    for (i = 0; i < tr.length; i++)
//    {
//        td = tr[i].getElementsByTagName("td")[1];
//        if(td)
//        {
//            if(td.innerHTML.toUpperCase().indexOf(filter) > -1)
//            {
//                tr[i].style.display = "";
//            }
//            else
//            {
//                tr[i].style.display = "none";
//            }
//        }
//    }
//}

