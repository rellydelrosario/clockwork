$(document).ready(function () {        
    LoadData();    
    SetSelectedValue();
});

function LoadData() {
    var options = {};
    options.url = "http://localhost:49850/api/currenttime/getlist";
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {        
        for (var i = 0; i < data.length; i++) {
            $(".tbody").append("<tr><td>" + data[i].currentTimeQueryId + "</td><td>" + data[i].clientIp + "</td><td>" + data[i].time + "</td><td>" + data[i].utcTime + "</td></tr>");
        }
    };
    options.error = function () {
        alert("fail");
    };
    $.ajax(options);
};

function GetTime() {
    var options = {};
    options.url = "http://localhost:49850/api/currenttime/get";
    options.type = "GET";
    options.data = { id: $("#localTimeZone").text().trim() };
    options.dataType = "json";
    options.success = function (data) {
        $(".tbody").append("<tr><td>" + data.currentTimeQueryId + "</td><td>" + data.clientIp + "</td><td>" + data.time + "</td><td>" + data.utcTime + "</td></tr>");  
    };
    options.error = function () {
        alert("fail");
    };
    $.ajax(options);
};

function RequestTime() {
    var options = {};
    options.url = "http://localhost:49850/api/currenttime/get";
    options.type = "GET";
    options.data = { id : $("#selTimeZone option:selected").text().trim() };
    options.dataType = "json";
    options.success = function (data) {     
        $(".tbody").append("<tr><td>" + data.currentTimeQueryId + "</td><td>" + data.clientIp + "</td><td>" + data.time + "</td><td>" + data.utcTime + "</td></tr>");
        $("#localTimeZone").html($("#selTimeZone option:selected").text().trim());
        SetSelectedValue();
    };
    options.error = function (error) {
        alert("fail");
    };
    $.ajax(options);
};

function SetSelectedValue()
{
    $("#selTimeZone option:contains(" + $("#localTimeZone").text().trim() + ")").prop("selected", true);
}

function formatDate(date)
{
    var dt = Date(date);
    var month = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    var day = dt.getDate();    
    var year = dt.getFullYear();
    var hour = dt.getHours();
    var min = dt.getMinutes();
    var amPm = '';

    if (day < 10) {
        day = "0" + day;
    }
    
    if (hour >= 12) {
        hour = parseInt(hour) - 12;
        amPm = "PM";
    }
    else
    {
        var amPm = "AM";
    }

    var dateTime = month[dt.getMonth() + 1] + " " + day + ", " + year + " " + hour + ":" + min + " " + amPm;
    return dateTime
}