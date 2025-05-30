$('span.noti').click(function (e) {
    debugger;
    e.stopPropagation();
    $('span.noti').css("color", "lightgreen");
    $('span.count').hide();
    $('.noti-content').show();
    var count = 0;
    count = parseInt($('span.count').html()) || 0;
    // only load notification if not already loaded
    if (count > 0) {
        updateNotification();
    }
    $('span.count', this).html('&nbsp;');
})
// hide notifications
$('html').click(function () {
    $('.noti-content').hide();
})
// update notification
function updateNotification() {
    $('#notiContent').empty();
    $('#notiContent').append($('<li>Loading...</li>'));
    $.ajax({
        type: 'GET',
        url: '/GroundGeneralLicenses/GetNotificationContacts',
        success: function (response) {
            debugger;
            $('#notiContent').empty();
            if (response.length == 0) {
                $('#notiContent').append($('<li>Currently You Have No New Notifications.</li>'));
            }
            $.each(response, function (index, value) {
                $('#notiContent').append($('<li>The User , ' + value.Name + '&nbsp;' + 'Of ID' + ' (' + value.ID + ') Is Written Something.</li>'));
            });
        },
        error: function (error) {
            console.log(error);
        }
    })
}
// update notification count
function updateNotificationCount() {
    $('span.count').show();
    var count = 0;
    count = parseInt($('span.count').html()) || 0;
    count++;
    $('span.noti').css("color", "white");
    $('span.count').css({ "background-color": "red", "color": "white" });
    $('span.count').html(count);

}
// signalr js code for start hub and send receive notification
var notificationHub = $.connection.notificationHub;
$.connection.hub.start().done(function () {
    console.log('Notification hub started');
});
//signalr method for push server message to client
notificationHub.client.notify = function (message) {
    if (message && message.toLowerCase() == "added") {
        updateNotificationCount();
    }
}