        //if (CanInitMap = "0") {
$(document).ready(function () {
    $("#findme").on("click", function (e) {
        e.preventDefault();
        initMap();
    });

    var map;
    var infowindow = null;
    var allowedZoomLevel = 6;
    var allowedMapBounds = new google.maps.LatLngBounds(
            new google.maps.LatLng(5.2852443672086515, 42.036873727280614),     //Map boundaries of Kenya approximately
            new google.maps.LatLng(-5.107266569317371, 33.621346383530614)
        );

    function initMap() {
        //if (CanInitMap = "0") {
        //Enabling new cartography and themes
        var xlat = document.getElementById('Latitude').value;
        var ylong = document.getElementById('Longitude').value;

        var lat = null;
        var lng = null;

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
            function (position) {
                var lat = position.coords.latitude;
                var lng = position.coords.longitude;
            });
        }

        var mEmpty = "";
        if (xlat == "" || xlat == null || xlat == 'null' || xlat == 'none' || xlat == 'n/a' || xlat == 'N/A' || xlat == '-') {
            if (lat == "" || lat == null) {
                xlat = -1.289802
                ylong = 36.825629711
            }
            else {
                xlat = lat;
                ylong = lng;
            }
            mEmpty = "x";
        }

        if (Math.abs(xlat) > 6) {
            xlat = 0;
        }
        if (Math.abs(ylong) > 45) {
            ylong = 36;
        }

        var actionUrl = 'https://maps.googleapis.com/maps/api/geocode/json?latlng=' + xlat + ',' + ylong + '&key=AIzaSyA5uJ8WtZCj9qCSm8Qnow01TJR3H8A6mHQ';
        $.getJSON(actionUrl, function (response) {
            if (response != null) {
                var x = 0;
                $.each(response, function (key, value) {
                    if (value.global_code != null) {
                        //document.getElementById('Pluscode').value = value.global_code;
                        document.getElementById('PlusCode').value = value.global_code;
                    }
                    if (value.compound_code != null) {
                        //document.getElementById('Address').value = value.compound_code;
                        document.getElementById('Address').value = value.compound_code;
                    }
                });
            }
        });

        google.maps.visualRefresh = true;
        //Setting starting options of map
        var mapOptions = {
            center: new google.maps.LatLng(xlat, ylong),
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.HYBRID
            //mapTypeId: google.maps.MapTypeId.SATELLITE
            //mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        //Getting map DOM element
        var mapElement = document.getElementById('map_canvas');
        //Creating a map with DOM element which is just
        //obtained
        map = new google.maps.Map(mapElement, mapOptions);

        var wmsOptions = {
            baseUrl: 'http://demo.cubewerx.com/cubewerx/cubeserv.cgi?',
            layers: 'Foundation.gtopo30',
            version: '1.1.1',
            styles: 'default',
            format: 'image/png'
        };

        google.maps.event.addListener(map, 'click', function (e) {
            //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
            //if (mEmpty != "") {
            if (infowindow != null)
                infowindow.close();

            infowindow = new google.maps.InfoWindow({
                content: '<b>Mouse Coordinates : </b><br><b>Latitude : </b>' + e.latLng.lat() + '<br><b>Longitude: </b>' + e.latLng.lng(),
                position: e.latLng
            });
            infowindow.open(map);

            document.getElementById('Latitude').value = e.latLng.lat();
            document.getElementById('Longitude').value = e.latLng.lng();

            var actionUrl = 'https://maps.googleapis.com/maps/api/geocode/json?latlng=' + e.latLng.lat() + ',' + e.latLng.lng() + '&key=AIzaSyA5uJ8WtZCj9qCSm8Qnow01TJR3H8A6mHQ';
            $.getJSON(actionUrl, function (response) {
                if (response != null) {
                    var x = 0;
                    $.each(response, function (key, value) {
                        if (value.global_code != null) {
                            //document.getElementById('Pluscode').value = value.global_code;
                            document.getElementById('PlusCode').value = value.global_code;
                        }
                        if (value.compound_code != null) {
                            //document.getElementById('Address').value = value.compound_code;
                            document.getElementById('Address').value = value.compound_code;
                        }
                    });

                }
            });

            //}
        });

        google.maps.event.addListener(map, 'drag', checkBounds);
        google.maps.event.addListener(map, 'zoom_changed', checkBounds);

        startButtonEvents();
        var myLatlng = new google.maps.LatLng(xlat, ylong);
        var marker = new google.maps.Marker({
            position: myLatlng,
            title: "lat: " + xlat + " long: " + ylong
        });

        //marker.setMap(map);
        //var infowindow = new google.maps.InfoWindow({ content: "<b>School</b><br/> Latitude:" + xlat + "<br /> Longitude:" + ylong + "" });
        //infowindow.open(map, marker);
        if (mEmpty == "") {
            marker.setMap(map);
            var infowindow = new google.maps.InfoWindow({ content: "<b>School Address</b><br/> Latitude:" + xlat + "<br /> Longitude:" + ylong + "" });
            infowindow.open(map, marker);
        }
        else {
            marker.setMap(map);
            var infowindow = new google.maps.InfoWindow({ content: "<b>Current Address</b><br/> Latitude:" + xlat + "<br /> Longitude:" + ylong + "" });
            infowindow.open(map, marker);
        }

        var infowindow = new google.maps.InfoWindow({
            content: 'Marker Info Window – ID : ' + marker
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });
        //}
    }

    function checkBounds() {
        if (map.getZoom() < allowedZoomLevel)
            map.setZoom(allowedZoomLevel);
    }

    function startButtonEvents() {
        document.getElementById('addStandardMarker').
        addEventListener('click', function () {
            addStandardMarker();
        });
        document.getElementById('addIconMarker').
        addEventListener('click', function () {
            addIconMarker();
        });
    }

    function startButtonEvents() {
        document.getElementById('btnRoad'
        ).addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.ROADMAP);
        });
        document.getElementById('btnSat'
        ).addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.SATELLITE);
        });
        document.getElementById('btnHyb'
        ).addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.HYBRID);
        });
        document.getElementById('btnTer'
        ).addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.TERRAIN);
        });
    }

    function createRandomLatLng() {
        var deltaLat = maxLat - minLat;
        var deltaLng = maxLng - minLng;
        var rndNumLat = Math.random();
        var newLat = minLat + rndNumLat * deltaLat;
        var rndNumLng = Math.random();
        var newLng = minLng + rndNumLng * deltaLng;
        return new google.maps.LatLng(newLat, newLng);
    }

    function addStandardMarker() {
        var coordinate = createRandomLatLng();
        var marker = new google.maps.Marker({
            position: coordinate,
            map: map,
            title: 'Random Marker - ' + markerId
        });
        // If you don't specify a Map during the initialization
        //of the Marker you can add it later using the line
        //below
        //marker.setMap(map);
        markerId++;
    }

    //google.maps.event.addDomListener(window, 'click', initMap);
    //}

    if (CanInitMap = "0") {
        initMap();
    }
});