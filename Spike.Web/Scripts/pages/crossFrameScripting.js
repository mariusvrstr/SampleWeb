
Project.page = function () {
    var objectFactory = {};
    var dataAccess = {};
    var links = {};

    return {
        objectFactory: objectFactory,
        dataAccess: dataAccess,
        links: links
    }
}();


Project.page.createViewModel = function () {
    var loadIFrame = function () {
        var frame = document.getElementById("frameHolder");
        var location = undefined;

        console.log(Project.page.viewModel.iFrameOption);

        if (Project.page.viewModel.iFrameOption() === "loadable") {
            location = Project.page.links.allowedUrl;
        } else if (Project.page.viewModel.iFrameOption() === "unloadable") {
            location = Project.page.links.notAllowedUrl;
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