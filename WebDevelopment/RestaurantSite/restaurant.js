function clearErrors() {    
    for (var loopCounter = 0; 
        loopCounter < document.forms["contactForm"].elements.length; 
        loopCounter++) {
        if (document.forms["contactForm"].elements[loopCounter]
           .parentElement.className.indexOf("has-") != -1) {
            
            document.forms["contactForm"].elements[loopCounter]
               .parentElement.className = "form-group";
        }
    }    
}

function resetForm() {
    //clearErrors();
	console.log("hiiii");
    document.forms["contactForm"]["inputName"].value = "";
	document.forms["contactForm"]["inputName"].focus();
    document.forms["contactForm"]["inputEmail"].value = "";  
	document.forms["contactForm"]["inputPhone"].value = "";  
	document.forms["contactForm"]["exampleFormControlSelect1"].value = "";  
	document.forms["contactForm"]["inputAdditionalInfo"].value = "";  
	document.forms["contactForm"]["inlineRadioOptions"].value = "Yes";  
	document.forms["contactForm"]["inlineRadioOptions"].checked();
	document.forms["contactForm"]["formlbl"].value = "M";
	document.forms["contactForm"]["formlbl"].checked();						
}

function validateItems() {
    clearErrors();
    var name = document.forms["contactForm"]["inputName"].value;
    var email = document.forms["contactForm"]["inputEmail"].value;
	var phone = document.forms["contactForm"]["inputPhone"].value;
	var additionalInfo = document.forms["contactForm"]["inputAdditionalInfo"].value;
	
	if(name == "" || name == null)
	{
		alert("Please enter valid Name.");
		return false;
	}
	
	if(email == "" || email == null)
	{
		alert("Please enter valid Email-id.");
		return false;
	}
	
	if(phone == "" || isNaN(phone))
	{
		alert("Please enter valid phone no.");
		return false;
	}
	
	if(additionalInfo == "" || additionalInfo == null)
	{
		alert("Please enter Additional info for better understanding.");
		return false;
	}
	return false;
   /* if (num1 == "" || isNaN(num1)) {
        alert("Num1 must be filled in with a number.");
        document.forms["numberFun"]["num1"]
           .parentElement.className = "form-group has-error";
        document.forms["numberFun"]["num1"].focus();
        return false;
    }*/
}
 
