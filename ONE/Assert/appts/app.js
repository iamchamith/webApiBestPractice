/// <reference path="bean.ts" />
var One;
(function (One) {
    var student = (function () {
        var url = "/api/StudentService/";
        var $studentViewModel = new kendo.data.ObservableObject();
        function insert_(e) {
            var d;
            d.Address = "aaa";
            d.Dob = "1988-8-8";
            d.Email = "iamchamith@gmail.com";
            d.Name = "janson";
            d.Phone = "123132132";
            return $.ajax({
                url: url + 'Insert',
                method: 'post',
                data: JSON.stringify(e)
            });
        }
        function update_(e) {
            return $.ajax({
                url: '',
                method: 'put',
                data: JSON.stringify(e)
            });
        }
        function delete_(e) {
            return $.ajax({
                url: '',
                method: 'delete',
                data: JSON.stringify(e)
            });
        }
        function get_(e) {
            return $.ajax({
                url: url + 'Get',
                method: 'get',
                data: e
            });
        }
        function getSingle_(e) {
            return $.ajax({
                url: url + 'GetSingle',
                method: 'get',
                data: { studentId: e }
            });
        }
        function setMvvm(e) {
            $studentViewModel = kendo.observable({
                Name: e.Name,
                Address: e.Address,
                Phone: e.Phone,
                Email: e.Email,
                Dob: e.Dob,
                IsVisibleSave: e.IsVisibleSave,
                IsVisibleUpdate: e.IsVisibleUpdate,
                IsVisibleDelete: e.IsVisibleDelete,
                Insert: function (p) {
                    if (confirm('sure insert?')) {
                        insert_(p.data).done(function (e) {
                            alert('success');
                        });
                    }
                },
                Update: function () { alert('Update'); },
                Delete: function () { alert('Delete'); }
            });
        }
        function ModelOpen(e) {
            setMvvm(e);
            kendo.bind($("#frmStudent"), $studentViewModel);
            $("#frmStudent").modal('show').appendTo('body');
        }
        return {
            init: function () {
                $("#main-placeHolder").html($("#template-student").html());
                $('#btnCreateStudentModelOpen').off().bind('click', null, function () {
                    var e = new MVVM.Student();
                    e.IsVisibleSave = true;
                    e.IsVisibleUpdate = false;
                    e.IsVisibleDelete = false;
                    ModelOpen(e);
                });
                $('#gv-student').kendoGrid({
                    columns: [
                        { field: "Id", hidden: true },
                        { field: "Name" },
                        { field: "Email" },
                        {
                            command: [{
                                    name: "details",
                                    click: function (e) {
                                        e.preventDefault();
                                        var tr = $(e.target).closest("tr");
                                        var data = this.dataItem(tr);
                                        console.log("Details for: " + data.Id);
                                        getSingle_(data.Id).done(function (e) {
                                            e.IsVisibleSave = false;
                                            e.IsVisibleUpdate = true;
                                            e.IsVisibleDelete = true;
                                            ModelOpen(e);
                                        });
                                    }
                                }]
                        }
                    ],
                });
                $('#dtStudentDob').kendoDatePicker();
                student().get();
            },
            get: function () {
                get_().done(function (e) {
                    $('#gv-student').data("kendoGrid").setDataSource(new kendo.data.DataSource({ data: e }));
                });
            }
        };
    });
    var subject = (function () {
        function insert() {
            return $.ajax({});
        }
        function update() {
            return $.ajax({});
        }
        function delete_() {
            return $.ajax({});
        }
        function get() {
            return $.ajax({});
        }
        return {
            init: function () {
            },
            get: function () {
            },
            insert: function () {
            },
            update: function () {
            }
        };
    });
    function load() {
        $('.menu').bind('click', function (e) {
            if ($(e.target).attr('data-bind') == 'student') {
                student().init();
            }
            else {
                subject().init();
            }
        });
        student().init();
    }
    $(function () { load(); });
})(One || (One = {}));
//# sourceMappingURL=app.js.map