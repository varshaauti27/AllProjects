var changeReturnDict = {
	Quarters : 0,
	Dimes : 0,
	Nickels : 0,
	Pennies : 0
};

$(document).ready(function(){
	
	loadAllItems();
});

function loadAllItems()
{
	clearDisplayItemsDiv();
	
	var newRowDiv = '<div class="row col-md-offset-1">';
	
	$.ajax({
		type: 'GET',
		url: 'http://tsg-vending.herokuapp.com/items',
		success: function(itemArray){
			var itemDiv = newRowDiv;
			$.each(itemArray,function(index,item){
				var id = item.id;
				var name = item.name;
				var price = item.price;
				var quantity = item.quantity;
				
				//alert("Index : "+index);
				if(index%3==0)
				{	
					itemDiv +='</div>';
					itemDiv += newRowDiv;
					itemDiv += '<div class="col-md-3 panel panel-default" id="item" onclick="addItemToBusinessForm('+ id +');"><div id="itemId">'+ id +'</div>';
				}
				else
				{
					itemDiv += '<div class="col-md-3 col-md-offset-1 panel panel-default" id="item" onclick="addItemToBusinessForm('+ id +');"><div id="itemId">'+ id +'</div>';
				}	
				
				itemDiv += '<div class="panel-body text-center"><b>'+ name +'</b></div>';
				itemDiv += '<div class="text-center">'+ price +'</div>';
				itemDiv += '<div class="panel-body text-center">Quantity left : '+ quantity +'</div>';
				itemDiv += '</div>';
			});
			$('#displayItemsDiv').append(itemDiv);
		},
		error: function(){
			$('#errorMessages').empty();
			$('#errorMessages')
				.append($('<li>')
				.attr({class: 'list-group-item list-group-item-danger'})
				.text('Error in calling web service. Please try again later...'));
		} 
	});
}

function clearDisplayItemsDiv()
{
	$('#displayItemsDiv').empty();
}

function addItemToBusinessForm(itemId)
{
	$('#item-purchase-text').val(itemId);
	$('#messages-text').val('');
	$('#change-return-text').val('');
	alert(changeReturnDict['Quarters'] * 0.25);
	var total = (changeReturnDict['Quarters'] * 0.25) +(changeReturnDict['Dimes'] * 0.10) + (changeReturnDict['Nickels'] * 0.05) + (changeReturnDict['Pennies'] * 0.01);
	if(total > 0)
	{
		$('#total-dollar-In-text').val(total);
	}
	changeReturnDict['Quarters'] = 0;
	changeReturnDict['Dimes'] = 0;
	changeReturnDict['Nickels'] = 0;
	changeReturnDict['Pennies'] = 0;
}

function addDollarInTotal()
{
	if($('#total-dollar-In-text').val()==='')
	{
		$('#total-dollar-In-text').val((1).toFixed(2));
	}
	else
	{
		$('#total-dollar-In-text').val((+$('#total-dollar-In-text').val()+1).toFixed(2));
	}
}

function addQuarterInTotal()
{
	if($('#total-dollar-In-text').val()==='')
	{
		$('#total-dollar-In-text').val(0.25);
	}
	else
	{
		$('#total-dollar-In-text').val((+$('#total-dollar-In-text').val() + 0.25).toFixed(2));
	}
}

function addDimeInTotal()
{
	if($('#total-dollar-In-text').val()==='')
	{
		$('#total-dollar-In-text').val(0.10);
	}
	else
	{
		$('#total-dollar-In-text').val((+$('#total-dollar-In-text').val() + 0.10).toFixed(2));
	}
}
function addNickelInTotal()
{
	if($('#total-dollar-In-text').val()==='')
	{
		$('#total-dollar-In-text').val(0.05);
	}
	else
	{
		$('#total-dollar-In-text').val((+$('#total-dollar-In-text').val() + 0.05).toFixed(2));
	}
}

function changeReturnClick()
{
	$('#item-purchase-text').val('');
	$('#messages-text').val('');
	$('#total-dollar-In-text').val('');
	$('#change-return-text').val('');
	changeReturnDict['Quarters'] = 0;
	changeReturnDict['Dimes'] = 0;
	changeReturnDict['Nickels'] = 0;
	changeReturnDict['Pennies'] = 0;
}

function makePurchase()
{
	if($('#item-purchase-text').val()==='')
	{
		$('#messages-text').val("Please make a selection");
		return;
	}
	if($('#total-dollar-In-text').val()==='')
	{
		$('#messages-text').val("Please add amount");
		return;
	}
	
	var URL ='http://tsg-vending.herokuapp.com/money/' + $('#total-dollar-In-text').val() + '/item/' + $('#item-purchase-text').val();
	
	$.ajax({
		type: 'POST',
		url: URL,
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json',
		},
		'dataType': 'json',
		success: function(data){
			$('#errorMessages').empty();
			var changeReturn="";
			var isPreChangeValueFound = false;
			
			changeReturnDict['Quarters'] = changeReturnDict['Quarters'] + data.quarters;
			changeReturnDict['Dimes']= changeReturnDict['Dimes'] + data.dimes;
			changeReturnDict['Nickels'] = changeReturnDict['Nickels'] + data.nickels;
			changeReturnClick['Pennies'] = changeReturnDict['Pennies'] + data.pennies;
			
			/*if(data.quarters!=0)
			{
				changeReturn = data.quarters + ' quarters';
				isPreChangeValueFound = true;
			}
			if(data.dimes!=0)
			{
				if(isPreChangeValueFound)
				{
					changeReturn+=", ";
				}
				changeReturn+= data.dimes + ' dimes';
				isPreChangeValueFound = true;
			}
			if(data.nickels!=0)
			{
				if(isPreChangeValueFound)
				{
					changeReturn+=", ";
				}
				changeReturn+=data.dimes + ' nickels';
			}
			if(data.pennies!=0)
			{
				if(isPreChangeValueFound)
				{
					changeReturn+=", ";
				}
				changeReturn+=data.pennies + ' pennies';
			}*/
			
			$('#messages-text').val("Thank You !!!!!");
			//$('#change-return-text').val(changeReturn);
			SetChangeReturn();
			
			$('#total-dollar-In-text').val('');
			$('#item-purchase-text').val('');
			loadAllItems();
		},
		error: function(error){
			$('#errorMessages').empty();
			if(error.status===422)
			{
				$('#messages-text').val(error.responseJSON.message);
			}
			else
			{
				$('#errorMessages')
				.append($('<li>')
				.attr({class: 'list-group-item list-group-item-danger'})
				.text('Error in calling web service. Please try again later...'));
			}
			loadAllItems();
		}
	});
}

function SetChangeReturn()
{
	var output ='';
	var flag = false;
	if(changeReturnDict['Quarters'] != 0)
	{
		output += changeReturnDict['Quarters'] + ' quarters';
		flag = true;
	}
	if(changeReturnDict['Dimes'] != 0)
	{
		if(flag)
			output+=', '
		output += changeReturnDict['Dimes'] + ' Dimes';
		flag = true;
	}
	if(changeReturnDict['Nickels'] != 0)
	{
		if(flag)
			output+=', '
		output += changeReturnDict['Nickels'] + ' Nickels';
		flag = true;
	}
	if(changeReturnDict['Pennies'] != 0)
	{
		if(flag)
			output+=', '
		output += changeReturnDict['Pennies'] + ' Pennies';
	}
	$('#change-return-text').val(output);
}