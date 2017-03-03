var app = angular.module("myApp", ["ngRoute"]);
var basePath = "../../pages/templates";
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            template: "<h1>WelCome to Student Management system</h1>"
        })
        .when("/student", {
            controller: 'student',
            templateUrl: basePath + "/student.html",
            resolve: {
                init: function () {
                    return function ($route) {
                        updateLeftMenuActived('student');
                        One.Student.init();
                    }
                }
            }
        })
        .when("/login", {
            controller: 'login',
            templateUrl: basePath + "/authontication.html",
            resolve: {
                init: function () {
                    return function ($route) {
                        One.Authontication.init();
                    }
                }
            }
        }).when("/errors", {
            controller: 'errors',
            templateUrl: basePath + "/errors.html",
            resolve: {
                init: function () {
                    return function ($route) {
                        updateLeftMenuActived('errors');
                    }
                }
            }
        }).when("/report", {
            controller: 'report',
            templateUrl: basePath + "/report.html",
            resolve: {
                init: function () {
                    return function ($route) {
                        updateLeftMenuActived('report');
                    }
                }
            }
        });
}).controller('student', ['$scope', '$route', 'init',
    function ($scope, $route, init) {
        init($route);
    }]).controller('login', ['$scope', '$route', 'init',
        function ($scope, $route, init) {
            init($route);
        }]).controller('errors', ['$scope', '$route', 'init',
            function ($scope, $route, init) {
                init($route);
            }]).controller('report', ['$scope', '$route', 'init',
                function ($scope, $route, init) {
                    init($route);
                }]);

function updateLeftMenuActived(selectedMenu: string): void {
    $('.lm').removeClass('active');
    $("[data-menu='"+selectedMenu+"']").addClass('active');
}