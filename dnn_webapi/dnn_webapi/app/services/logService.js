'use strict';
app.factory('logService', ['$http', function ($http) {

    var serviceBase = 'http://meljab.dynalias.net/dnn_webapi/api/mylog';
    var logsServiceFactory = { };

    var _getLogs = function () {
        return $http.get(serviceBase + '?$top=5&$orderby=ItemID desc').success(function (data) {
            return data;
        });
    };

    var _insertlog = function (callback, log) {
        var log = { "Entry": log.Entry, "UserName": log.UserName };
        $http.post(serviceBase, log).success(callback);
    };

    var _updatelog = function (callback, log) {
        var log = { "ItemID": log.ItemID, "EntryDate": log.EntryDate, "Entry": log.Entry, "UserName": log.UserName };
        $http.put(serviceBase, log).success(callback);
    };

    var _deletelog = function (callback, id) {
        $http.delete(serviceBase + '?itemid=' + id).success(callback);
    };

    logsServiceFactory.getLogs = _getLogs;
    logsServiceFactory.insertlog = _insertlog;
    logsServiceFactory.updatelog = _updatelog;
    logsServiceFactory.deletelog = _deletelog;

    return logsServiceFactory;

}]);