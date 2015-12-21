Project.page = function() {
    var objectFactory = {};
    var dataAccess = {};
    var links = {};

    return {
        objectFactory: objectFactory,
        dataAccess: dataAccess,
        links: links
    }
}();

Project.page.objectFactory = function () {
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

Project.page.createViewModel = function(serverData) {
    Project.console.log(serverData);

    var sectionTitle = serverData.SectionTitle;
    var methods = ko.observable(Project.page.objectFactory.getClientMethods(serverData.MethodList));

    var getAjaxJsonServerData = function() {
        Project.page.console.error("getAjaxJsonServerData not implimented yet");
    };

    var getAjaxHtmlServerData = function () {
        Project.page.console.error("getAjaxHtmlServerData not implimented yet");
    };

    return {
        sectionTitle: sectionTitle,
        methods: methods,
        getAjaxJsonServerData: getAjaxJsonServerData,
        getAjaxHtmlServerData: getAjaxHtmlServerData
    }
};

Project.page.dataAccess = function() {


    return {
        
    }
}();





