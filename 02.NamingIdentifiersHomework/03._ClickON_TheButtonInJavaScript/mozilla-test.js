function onCheckIfMozillaButton() {
    'use strict';

    var browserName = window.navigator.appCodeName,
        isMozilla = browserName === "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}