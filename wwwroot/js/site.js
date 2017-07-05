// Write your Javascript code.
        var map = null;

        function GetMap() {
            map = new VEMap('myMap');
            map.LoadMap(new VELatLong(47.62054, -122.34947), 16, VEMapStyle.Road, false);
            var pinpoint = map.GetCenter();
            shape = new VEShape(VEShapeType.Pushpin, pinpoint);
            shape.SetTitle("Mununga sub-location, Kigio Location");
            shape.SetDescription("This is where we are located!");
            map.AddShape(shape);
        }

        function GetDirections() {
            var what = document.getElementById('from').value;
            var options = new VERouteOptions();
            options.DrawRoute = true;
            options.SetBestMapView = false;
            options.RouteCallback = onGotRoute;
            map.GetDirections([what, map.GetCenter()], options);
        }

        function onGotRoute(route) {
            var legs = route.RouteLegs;
            var turns = "Total distance: " + route.Distance.toFixed(1) + " mi\n";
            var numTurns = 0;
            var leg = null;
            for (var i = 0; i < legs.length; i++) {
                leg = legs[i];
                var turn = null;
                for (var j = 0; j < leg.Itinerary.Items.length; j++) {
                    turn = leg.Itinerary.Items[j];
                    numTurns++;
                    turns += numTurns + ".\t" + turn.Text + " (" + turn.Distance.toFixed(1) + " mi)\n";
                }
            }
            document.getElementById("directions").value = turns;
        }




    //CountDownTimer('02/19/2012 10:1 AM', 'countdown');
    CountDownTimer('07/06/2017 06:00 AM', 'newcountdown');

    function CountDownTimer(dt, id)
    {
        var end = new Date(dt);

        var _second = 1000;
        var _minute = _second * 60;
        var _hour = _minute * 60;
        var _day = _hour * 24;
        var timer;

        function showRemaining() {
            var now = new Date();
            var distance = end - now;
            if (distance < 0) {

                clearInterval(timer);
                document.getElementById(id).innerHTML = 'EXPIRED!';

                return;
            }
            var days = Math.floor(distance / _day);
            var hours = Math.floor((distance % _day) / _hour);
            var minutes = Math.floor((distance % _hour) / _minute);
            var seconds = Math.floor((distance % _minute) / _second);

            document.getElementById(id).innerHTML = days + ' days ';
            document.getElementById(id).innerHTML += hours + ' hrs ';
            document.getElementById(id).innerHTML += minutes + ' mins ';
            document.getElementById(id).innerHTML += seconds + ' secs';
        }

        timer = setInterval(showRemaining, 1000);
    }

    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        m = checkTime(m);
        s = checkTime(s);
        document.getElementById('txt').innerHTML = "The time is " + h + ":" + m + ":" + s;
        var t = setTimeout(startTime, 500);
    }
    function checkTime(i) {
        if (i < 10) {i = "0" + i};  // add zero in front of numbers < 10
        return i;
    }
    
    (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));
    
    document.getElementById('ogBtn').onclick = function() {
        FB.ui({
            display: 'popup',
            method: 'share_open_graph',
            action_type: 'og.likes',
            action_properties: JSON.stringify({
                object:'https://developers.facebook.com/docs/',
            })
        }, function(response){});
    }