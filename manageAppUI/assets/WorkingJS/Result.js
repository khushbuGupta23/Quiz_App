var app = angular.module('ResultModule', ['UserHomeModule']);

app.service('ResultService', function ($http, $location) {
   
    this.GetUserTestResult = function (Subject_Id,UserName) {
        return $http.get('/api/Result/GetUserTestResult?Subject_Id=' + Subject_Id +'&UserName=' + UserName);
    }
    this.GetTestResultByUserName = function (UserName) {
        return $http.get('/api/Result/GetTestResultByUserName?UserName=' + UserName);
    }
    this.getResultview = function () {
        return $http.get('/api/Result/TestResultList');
    }

    this.UploadExcel = function (fd) {
        return $http.post('/api/Result/UploadExel', fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        });
    };

   
});


app.controller('ResultController', function ($scope, ResultService, UserhomeService) {

    $scope.ShowLevel = false;
    $scope.ShowSubject = true;
    $scope.Subject_Id = UserhomeService.Subject_Id;

    $scope.UserName = angular.fromJson(sessionStorage.getItem("app")).UserName;
    $scope.Role = angular.fromJson(sessionStorage.getItem("app")).Role;
    $scope.init = function () {
        $scope.serachText = '';
        debugger;
        if ($scope.Subject_Id == null && $scope.Role == "Admin" ) {

            ResultService.getResultview().then(function (success) {
               
                    $scope.ResultSheetArray = success.data
              
               
            });
            if ($scope.UserName != null && $scope.Role != "Admin") {
                ResultService.GetTestResultByUserName($scope.UserName).then(function (success) {
                    $scope.ResultSheetArray = success.data
                });
                
            } 
        } else {
            ResultService.GetUserTestResult($scope.Subject_Id, $scope.UserName).then(function (success) {
                if (success.data != null) {
                    $scope.ResultSheetArray = success.data
                    swal({
                        title: 'Congratulations!',

                        type: 'success'
                    });
                }

            },
                function (error) {
                    console.log(error.data);
                    swal("no Record");


                });
        }


    }

    $scope.exportExcel = function () {

        alasql('SELECT * INTO XLSX("ResultSheet.xlsx",{headers:true}) \ FROM HTML("#HtmlResultSheetArray",{headers:true})');
    }
   

    $scope.Upload = function () {

        console.log("upload");
        var file = $scope.myFile;

        console.log(file);
        var fd = new FormData();
        console.log(fd);
        fd.append('file', file);

        console.log(file);
        if (file) {

            var obj = {
                Subject_Id: UserhomeService.Subject_Id,
                UserName: angular.fromJson(sessionStorage.getItem("app")).UserName,
            };

            fd.append('data', angular.toJson(obj));
            console.log(fd);

            ResultService.UploadExcel(fd).then(function (success) {
                console.log("$scopeReport", success);
                console.log("$scopeReport", success.data);
                if (success.data == 'Success') {
                    swal("Success", success.data, "success");
                }
                else {
                    swal("Error", success.data, "error");
                    return false;
                }


            },
                function (error) {
                    console.log(error);
                    swal("Error", error.data.ExceptionMessage, "error");
                });
        }
        else {
            swal("", "Please upload Attachment", "error");
        }

    };
   
   
    $scope.init();

});