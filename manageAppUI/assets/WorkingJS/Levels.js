

var app = angular.module('levelModule', []);


app.service('LevelService', function ($http, $location) {

    this.prevPage;
    this.currentPage = 1;
    this.index = 1;
    this.AppUrl = "";
    console.log($location.absUrl());
  
    this.AppUrl = "";
    if ($location.absUrl().indexOf('CST') != -1) {
        this.AppUrl = "/CST/api/";
    }
    else {
        this.AppUrl = "/api/";
    }

    this.IsStarted = false;
    this.ProgramArray= [];
    this.QuestionVariable = {};
    this.QuestionAnswer = [];

    this.GetQuestionBySubjectId = function (Subject_Id) {
        return $http.post(this.AppUrl + '/QuestionBank/GetQuestionbySubject_Id?Subject_Id=' + Subject_Id);
    }
   
    this.SaveTestResponse = function (obj) {
        return $http.post(this.AppUrl + '/QuizT/AddQuiz', obj);
    }

    this.SaveTestResponse2 = function (obj) {
        return $http.put(this.AppUrl + '/UserAnswer/updateUserAnswer',obj)
    }
    this.AuthUser = function (UserName) {

        return $http.get(this.AppUrl + 'Login/AuthUser/?UserName=' + UserName);
    }
    this.GetSubject = function () {
        return $http.get(this.AppUrl + '/Subject/GetList');
    }

});


app.controller('LevelController', function ($scope, $http, $location, LevelService, $rootScope,  UserhomeService) {
    $scope.defaultConfig = {
        'allowBack': true,
        'allowReview': true,
        'autoMove': false, 
        'pageSize': 1,
        'requiredAll': false,  
        'richText': false,
        'shuffleQuestions': false,
        'shuffleOptions': false,
        'showPager': true,
        'theme': 'none'
    }
    $scope.QuestionAnswer = [];
    $scope.dirOptions = {};
    $scope.quizName = "data";

    $scope.ShowStartButton = true;
    $scope.ShowDirective = false;
    $scope.ShowNextbutton = true;
    $scope.User_Id = angular.fromJson(sessionStorage.getItem("app")).User_Id;
    $scope.UserName = angular.fromJson(sessionStorage.getItem("app")).UserName;
    $scope.Subject_Id = UserhomeService.Subject_Id;
    $scope.init = function () {
        $scope.question= {
            Question_Id:null,
            Subject_Id: $scope.Subject_Id,
            TotalQues: null,
            Question: null,
            AnswerGiven:null,
            CreatedBy: null,
            ModifiedBy: null,
            UserName: $scope.UserName,
        };
        $rootScope.UserName = $scope.UserName;
        $scope.dirOptions = {};
        $scope.Subject_Id = UserhomeService.Subject_Id;
        LevelService.GetQuestionBySubjectId($scope.Subject_Id).then(function (success) {
            if (success.data != null) {
                $scope.questions = success.data;
                $scope.totalItems = $scope.questions.length;
                $scope.config = ($scope.defaultConfig);
                $scope.itemsPerPage = $scope.defaultConfig.pageSize;
                $scope.currentPage = 1;
                LevelService.currentPage = $scope.currentPage;
                $scope.mode = 'quiz';
                
                $scope.$watch('currentPage + itemsPerPage', function () {
                    var begin = (($scope.currentPage - 1) * $scope.itemsPerPage),
                        end = begin + $scope.itemsPerPage;
                    $scope.ProgramArray = $scope.questions.slice(begin, end);
                });
                $scope.ShowStartButton = true;
                $scope.ShowQuestions = false;
            } else {
                alert("No Question Set in This Subject");
            }
            LevelService.QuestionVariable = {
                UserName: $scope.UserName,
                Subject_Id: $scope.ProgramArray[0].Subject_Id,
                Question_Id: $scope.ProgramArray[0].Question_Id,
                AnswerGiven: $scope.ProgramArray[0].AnswerGiven,
                ModifiedBy: 2,
                UserName: $scope.UserName,

            }
            console.log("User_Id",$scope.User_Id);
          
        },function (error) {
        });
    };

  
    $scope.goTo = function (index, obj) {
        

        console.log("Status", $scope.IsStatusCode);
        if ($scope.ProgramArray[0].AnswerGiven != null) {
           
            LevelService.prevPage = $scope.currentPage - 1;

            console.log($scope.totalItems);
           
            if ($scope.currentPage == $scope.totalItems ) {
                console.log(LevelService.QuestionVariable);
                
                $scope.ShowNextbutton = false;
                
              
            }
            else {

                $scope.ShowNextbutton = true;

            }
            var obj = {
                ProgramArray: LevelService.QuestionVariable,
                Question_Id: $scope.ProgramArray[0].Question_Id,
                Subject_Id: $scope.ProgramArray[0].Subject_Id,
                AnswerGiven: $scope.ProgramArray[0].AnswerGiven,
                CreatedBy: 2,
                ModifiedBy: null,
                UserName: $scope.UserName,
            };
            $scope.QuestionAnswer.push(
                {
                    Question_Id: obj.Question_Id,
                    AnswerGiven: obj.AnswerGiven,
                    ModifiedBy: 2,
                    UserName: $scope.UserName,
                    Subject_Id: obj.Subject_Id

                });
            console.log("Datasave", $scope.QuestionAnswer);
            if (index > 0 && index <= $scope.totalItems) {
                console.log("index", index);
                $scope.currentPage = index;
                console.log("currentpage", $scope.currentPage);
                $scope.mode = 'quiz';
            }


            

           
        } else {
            swal("please select Answer");
        }

    };

    //$scope.isAnswered = function (pt) {
    //    var answered = 'Not Answered';
    //    console.log($scope.questions[index].AnswerGiven, "index=", index);
      
    //    if (pt.AnswerGiven != null) {
    //        console.log(pt.AnswerGiven);
    //        return "answered";
    //    }
    //    else { return "unanswered"; }
    //    return answered;
    //};
    //$scope.isCorrect = function (question) {
    //    var result = 'correct';
    //    question.Options.forEach(function (option, index, array) {
    //        if (helper.toBool(option.Selected) != option.IsAnswer) {
    //            result = 'wrong';
    //            return false;
    //        }
    //    });
    //    return result;
    //};

    $scope.pageCount = function () {
        return Math.ceil($scope.questions.length / $scope.itemsPerPage);
    };
    $scope.onSelect = function (question, option) {
        if (question.QuestionTypeId == 1) {
            question.Options.forEach(function (element) {
                if (element.Id != option.Id) {
                    element.Selected = false;
                }
            });
        }
        if ($scope.config.autoMove == true && $scope.currentPage < $scope.totalItems) {
        }
    }

  
    $scope.Submit = function () {
        $scope.AnsweredAllQuestion = true;
        
        angular.forEach($scope.ProgramArray, function (value) {
            if (!value.AnswerGiven) {
                $scope.AnsweredAllQuestion = false;
            }
        });
        
        if ($scope.AnsweredAllQuestion == false) {
            swal({
                title: 'Are you sure?',
                text: "You have not answered all questions! ",
                type: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'OK'
            }).then((result) => {
                
                console.log("Qv", $scope.QuestionAnswer);
                LevelService.SaveTestResponse2($scope.QuestionAnswer).then(function success(success) {
                    $scope.IsStatusCode = success.data;
                    swal({
                        title: 'Thanks',
                        text: "You have submitted Test successfully",
                        type: 'success',
                        showCancelButton: false,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        window.location.href = '/UserHome.html';
                    });
                }, function error(Error) {
                });
            });
        }
        else {
            swal({
                title: 'Are you sure?',
                text: "You are going to submit test!",
                type: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel ',
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Submit it!'
            }).then((result) => {
               
                console.log("Qv", $scope.QuestionAnswer);
                LevelService.SaveTestResponse2($scope.QuestionAnswer).then(function success(success) {
                    window.location.href = '#/Result/';
                   
                }, function error(Error) {
                });
            });
        }

    };
 
    


});
  
 

