spike.page = function() {
    var objectFactory = {};
    var dataAccess = {};
    var links = {};

    return {
        objectFactory: objectFactory,
        dataAccess: dataAccess,
        links: links
    }
}();

spike.page.objectFactory = function () {
    var getClientMethod = function(item) {
        return {
            name: item.Name
        };
    };

    var getClientMethods = function(items) {
        var list = $.map(items, getClientMethod);
        return list;
    };

    return {
        getClientMethods: getClientMethods
    };
}();

spike.page.createViewModel = function(serverData) {
    spike.utilities.console.log(serverData);

    var sectionTitle = serverData.SectionTitle;
    var methods = ko.observable(spike.page.objectFactory.getClientMethods(serverData.MethodList));

    var getAjaxJsonServerData = function() {
        spike.page.console.error("getAjaxJsonServerData not implimented yet");
    };

    var getAjaxHtmlServerData = function () {
        spike.page.console.error("getAjaxHtmlServerData not implimented yet");
    };

    return {
        sectionTitle: sectionTitle,
        methods: methods,
        getAjaxJsonServerData: getAjaxJsonServerData,
        getAjaxHtmlServerData: getAjaxHtmlServerData
    }
};

spike.page.dataAccess = function() {


    return {
        
    }
}();





