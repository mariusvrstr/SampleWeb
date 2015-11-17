
spike.page = function () {
    var objectFactory = {};
    var dataAccess = {};
    var links = {};

    return {
        objectFactory: objectFactory,
        dataAccess: dataAccess,
        links: links
    }
}();


spike.page.createViewModel = function () {
    var loadIFrame = function () {
        var frame = document.getElementById("frameHolder");
        var location = undefined;

        console.log(spike.page.viewModel.iFrameOption);

        if (spike.page.viewModel.iFrameOption() === "loadable") {
            location = spike.page.links.allowedUrl;
        } else if (spike.page.viewModel.iFrameOption() === "unloadable") {
            location = spike.page.links.notAllowedUrl;
        }

        if (location != undefined) {
            console.log("Frame redirect to: " + location);
            frame.src = location;
        } else {
            console.log("No frame location to redirect to.");
        }

    };

    var iFrameOption = ko.observable("loadable");

    return {
        loadIFrame: loadIFrame,
        iFrameOption: iFrameOption
    }
}