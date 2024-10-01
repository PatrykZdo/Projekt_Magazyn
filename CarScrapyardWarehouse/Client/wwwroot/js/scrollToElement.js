window.scrollToElement = function (elementId) {
    var element = document.querySelector(elementId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}