
//var url = "http://localhost:60759/Admin/";
var url = "http://86e5809092cb478994f1900a6012ac93.cloudapp.net/Admin/";
function submitLogin() {

    var uname = $("#uname").val();
    var pword = $("#pword").val();

    var formdata = "uname=" + uname + "&pword=" + pword;
    

    $.ajax({
        type: "post",
        url: url+"validateLogin",
        data: formdata,
        success: function (result) {
            var status = result.status;
            var data = result.data;

            if (status == "success" && data == true) {
                alert("You've successfully log in.");
                window.location.href = "Accounts";
            } else {
                alert("Failed to Log in.");
            }

        }
    }, 'json');

}


//accounts here

function deleteAccount(username) {

    var answer = confirm("Do you really want to delete "+username+" account?");

    if (answer) {

       // alert(username);

        $.post(url+"deleteUserAccount", {username : username}, function (result) {
            if (result.data == true) {

                alert("You've successfully deleted an account.");
                window.location.href = "/Admin/Accounts";
            } else {
                alert("Failed to delete an account.");
            }
        });

    }

}

function EditAccountBtn() {

    document.getElementById('uname').disabled = true;
    document.getElementById('pword').disabled = true;
    document.getElementById('name').disabled = false;
    document.getElementById('email').disabled = false;
    document.getElementById('country').disabled = false;
    document.getElementById('address1').disabled = false;
    document.getElementById('address2').disabled = false;
    document.getElementById('city').disabled = false;
    document.getElementById('province').disabled = false;
    document.getElementById('postal').disabled = false;
    document.getElementById('telephone').disabled = false;
    document.getElementById('company').disabled = false;
}

function ResetAccountBtn() {

   // document.getElementById('uname').value = true;
   // document.getElementById('pword').value = true;
    document.getElementById('name').value = "";
    document.getElementById('email').value = "";
    document.getElementById('country').value = "";
    document.getElementById('address1').value = "";
    document.getElementById('address2').value = "";
    document.getElementById('city').value = "";
    document.getElementById('province').value = "";
    document.getElementById('postal').value = "";
    document.getElementById('telephone').value = "";
    document.getElementById('company').value = "";
}

function UpdateAccountBtn() {


    var uname = $("#uname");
    var pword = $("#pword");
    var name = $("#name");
    var email = $("#email");
    var country = $("#country");
    var address1 = $("#address1");
    var address2 = $("#address2");
    var city = $("#city");
    var province = $("#province");
    var company = $("#company");
    var postal = $("#postal");
    var tel = $("#telephone");

    if (name.val() == "") {
        alert("Please input a name.");
        name.focus();
    } else if (email.val() == "") {
        alert("Please input an email.");
        email.focus();
    } else {
        //save here
        var answer = confirm("Do you really want to update this news?");
        if (answer) {
            $.post(url + "updateAccount", { uname: uname.val(), pword: pword.val(), name: name.val(), email: email.val(), company: company.val(), country: country.val(), address1: address1.val(), address2: address2.val(), city: city.val(), province: province.val(), postal: postal.val(), tel: tel.val() }, function (result) {

                if (result.status == "success") {
                    alert("You've successfully updated an account.");
                    window.location.href = "/Admin/ViewAccounts/?username=" + uname.val() + "";
                }

            }, 'json');
        }

    }



}

//end

//news here

function AddNews() {

    window.location.href = "/Admin/AddNews";
}
function SubmitNewsBtn() {

    var title = $("#title");
    var m = $("#datemonth").val();
    var d = $("#dateday").val();
    var y = $("#dateyear").val();
    var date = y + "-" + m + "-" + d;
    var caption = $("#newscaption").val();
    var content = $("#newscontent");

    if (title.val() == "") {
        alert("Please input a title.");
        title.focus();
    } else if (content.val() == "") {
        alert("Please input a content");
        content.focus();
    } else {
        //save here
        $.post(url + "saveNews", { title: title.val(), fulldate: date, caption: caption, content: content.val() }, function (result) {

            if (result.status == "success") {
                alert("You've successfully created a news.");
                window.location.href = "/Admin/AddNews";
            }

        }, 'json');
    }
}

function ResetBtn() {

    
    $("#title").val("");
    $("#newscaption").val("");
    $("#newscontent").val("");
}

function deleteNews(id) {

    var answer = confirm("Do you really want to delete this news?");

    if (answer) {

        $.post(url + "deleteNews", { id:id }, function (result) {
            if (result.data == true) {

                alert("You've successfully deleted a news.");
                window.location.href = "/Admin/News";
            } else {
                alert("Failed to delete a news.");
            }
        });

    }

}

function EditNewsBtn() {

    document.getElementById('title').disabled = false;
    document.getElementById('newscaption').disabled = false;
    document.getElementById('newscontent').disabled = false;

}

function UpdateNewsBtn() {

  
        var id = $("#newsid").val();
        var title = $("#title");
        var m = $("#datemonth").val();
        var d = $("#dateday").val();
        var y = $("#dateyear").val();
        var date = y + "-" + m + "-" + d;
        var caption = $("#newscaption").val();
        var content = $("#newscontent");

        if (title.val() == "") {
            alert("Please input a title.");
            title.focus();
        } else if (content.val() == "") {
            alert("Please input a content");
            content.focus();
        } else {
            //save here
            var answer = confirm("Do you really want to update this news?");
            if (answer) {
                $.post(url + "updateNews", { title: title.val(), fulldate: date, caption: caption, content: content.val(),id:id }, function (result) {

                    if (result.status == "success") {
                        alert("You've successfully updated a news.");
                        window.location.href = "/Admin/ViewNews/?newsid="+id+"";
                    }

                }, 'json');
            }
           
        }

    

}

//end


