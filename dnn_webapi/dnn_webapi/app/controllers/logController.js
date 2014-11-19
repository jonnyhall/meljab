'use strict';
app.controller('logController', ['$scope', '$location',  'logService', function ($scope, $location, logService) {
   
        $scope.logData = [];
     
    
        getLogs();

       
        function getLogs() {
            logService.getLogs().success(function (data) {
                $scope.logData = data;
            }, function (error) {
                alert(error.data.message);
            });

        }


        $scope.setScope = function (obj, action) {

            $scope.action = action;
            $scope.New = obj;
        }

        $scope.gridOptions = {
            data: 'logData',
            rowHeight: 100,
            columnDefs: [
                { field: 'EntryDate', displayName: 'EntryDate', width: '15%' },
                { field: 'UserName', displayName: 'UserName', width: '15%' },
                { field: 'Entry', displayName: 'Entry', width: '50%', cellTemplate: '<div ng-class="{ngRowLogs: true}"><p ng-bind-html="row.entity.Entry"></p></div>' },
                { displayName: 'Options', cellTemplate: '<input type="button" ng-click="setScope(row.entity,\'edit\')" name="edit"  value="Edit">&nbsp;<input type="button" ng-click="Deletelog(row.entity.ItemID)"  name="delete"  value="Delete">', width: '25%' }
            ]
        };

        $scope.update = function () {
            if ($scope.action == 'edit') {
                logService.updatelog(function () {
                    $scope.status = 'log updated successfully';
                    alert('log updated successfully');
                    getLogs();
                }, $scope.New)
                $scope.action = '';
            }
            else {
                logService.insertlog(function () {
                    alert('log inserted successfully');
                    getLogs();
                }, $scope.New)

            }


        }



        $scope.Deletelog = function (id) {
            logService.deletelog(function () {
                alert('log deleted');
                getLogs();
            }, id)

        }

        //if (!$scope.$$phase) {
        //    $scope.$digest();
        //}

}]);