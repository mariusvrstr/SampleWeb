
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

Project.page.dataAccess = function () {

    var onGetDangerousSuccess = function (serverData) {
        console.log(serverData);

        Project.page.viewModel.htmlData(serverData.DangerouseHTMLCode);
        Project.page.viewModel.jsData(serverData.DangerouseJavaScript);

    };

    var onGetDangerousReplacementSuccess = function (serverData) {
        console.log(serverData);

        $('#ReplaceHolder').html(serverData);
    };

    var getData = function () {
        Project.ajax.submitAjaxRequest(Project.page.links.getDangerLink, {}, onGetDangerousSuccess);
    };

    var getReplacement = function () {
        Project.ajax.submitAjaxPartialRequest(Project.page.links.getDangerReplacementLink, {}, onGetDangerousReplacementSuccess);
    }

    return {
        getData: getData,
        getReplacement: getReplacement
    }
}();

Project.page.createViewModel = function (serverData) {
    console.log('Create View Model');
    console.log(Project.page.dataAccess.getData);

    var htmlData = ko.observable('Replace Me Text');
    var jsData = ko.observable('Replace Me Text'); 
    var rawJsData = ko.observable(serverData.DangerousJavaScript);
    
    return {
        getData: Project.page.dataAccess.getData,
        getReplacement: Project.page.dataAccess.getReplacement,
        htmlData: htmlData,
        jsData: jsData,
        rawJsData: rawJsData
    }
}

