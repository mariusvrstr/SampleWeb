
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

spike.page.dataAccess = function () {

    var onGetDangerousSuccess = function (serverData) {
        console.log(serverData);

        spike.page.viewModel.htmlData(serverData.DangerouseHTMLCode);
        spike.page.viewModel.jsData(serverData.DangerouseJavaScript);

    };

    var getData = function () {
        spike.ajax.submitAjaxRequest(spike.page.links.getDangerLink, {}, onGetDangerousSuccess);
    };

    return {
        getData: getData
    }
}();

spike.page.createViewModel = function () {
    console.log('Create View Model');
    console.log(spike.page.dataAccess.getData);

    var htmlData = ko.observable('Replace Me Text');
    var jsData = ko.observable('Replace Me Text');
    
    return {
        getData: spike.page.dataAccess.getData,
        htmlData: htmlData,
        jsData: jsData
    }
}

