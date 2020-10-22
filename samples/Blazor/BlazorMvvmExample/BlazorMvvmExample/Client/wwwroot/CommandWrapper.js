window.CommandWrapper = {
    removeDisabled: elem => {
        if (elem) {
            elem.disabled = false;
        }
    },
    setDisabled: elem => {
        if (elem) {
            elem.disabled = true;
        }
    },
    setClasses: function (elem, classes) {
        if (elem) {
            elem.className = classes;
        }
    },
    setClick: function (elem, obj, method) {
        if (elem) {
            elem.onclick = function () {
                obj.invokeMethodAsync(method);
            }
        }
    }
};