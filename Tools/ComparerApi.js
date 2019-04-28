var ComparerApi = function () {

    var owinUri = 'http://localhost:8887/api/test'
    var IISUri = 'http://localhost:54328/api/test'
    var owinUriSync = 'http://localhost:8887/api/testsync'
    var IISUriSync = 'http://localhost:54328/api/testsync'
    var counter = 0;
    var total = 2500;
    this.getOwinAsync = function () {
        counter = 0;
        var start = new Date().getTime();
        return Array.from(new Array(total)).map(function () {
            fetch(owinUri).then(function () {
                counter++;
                console.log("Counter: " + counter);
                if (counter == total) {
                    var end = new Date().getTime();
                    var elapsedTimeInMilliseconds = end - start;
                    console.log('Finished in: ' + elapsedTimeInMilliseconds + 'milliseconds');
                }
            }).then(function () {
                return Promise.resolve();
            })
        });
    }
    this.getIISAsync = function () {
        counter = 0;
        var start = new Date().getTime();
        return Array.from(new Array(total)).map(function () {
            fetch(IISUri).then(function () {
                counter++;
                console.log("Counter: " + counter);
                if (counter == total) {
                    var end = new Date().getTime();
                    var elapsedTimeInMilliseconds = end - start;
                    console.log('Finished in: ' + elapsedTimeInMilliseconds + 'milliseconds');
                }
            }).then(function () {
                return Promise.resolve();
            })
        });
    }
    this.getOwinSync = function () {
        counter = 0;
        var start = new Date().getTime();
        return Array.from(new Array(total)).map(function () {
            fetch(owinUriSync).then(function () {
                counter++;
                console.log("Counter: " + counter);
                if (counter == total) {
                    var end = new Date().getTime();
                    var elapsedTimeInMilliseconds = end - start;
                    console.log('Finished in: ' + elapsedTimeInMilliseconds + 'milliseconds');
                }
            }).then(function () {
                return Promise.resolve();
            })
        });
    }
    this.getIISSync = function () {
        counter = 0;
        var start = new Date().getTime();
        return Array.from(new Array(total)).map(function () {
            fetch(IISUriSync).then(function () {
                counter++;
                console.log("Counter: " + counter);
                if (counter == total) {
                    var end = new Date().getTime();
                    var elapsedTimeInMilliseconds = end - start;
                    console.log('Finished in: ' + elapsedTimeInMilliseconds + 'milliseconds');
                }
            }).then(function () {
                return Promise.resolve();
            })
        });
    }
}
