/// <reference path="bean.ts" />
/// <reference path="enums.ts" />
var One;
(function (One) {
    var student = (function () {
        //globle variables
        var dsStudents = new kendo.data.DataSource();
        var url = "/api/v1/student/";
        var $studentViewModel = new kendo.data.ObservableObject();
        //api calls
        var apiCalls = {
            insert_: function (e) {
                return $.ajax({
                    url: url,
                    contentType: "application/json;charset=utf-8",
                    method: 'post',
                    data: JSON.stringify(e)
                });
            },
            update_: function (e) {
                return $.ajax({
                    url: url,
                    contentType: "application/json;charset=utf-8",
                    method: 'put',
                    data: JSON.stringify(e)
                });
            },
            delete_: function (e) {
                return $.ajax({
                    url: url,
                    contentType: "application/json;charset=utf-8",
                    method: 'delete',
                    data: { Id: e.Id }
                });
            },
            get_: function (e) {
                return $.ajax({
                    url: url,
                    method: 'get',
                    contentType: "application/json;charset=utf-8",
                    data: e
                });
            }
        };
        // mvvm
        function getSingle_(e) {
            return $.ajax({
                url: url + "/" + e,
                method: 'get',
                contentType: "application/json;charset=utf-8",
                data: null
            });
        }
        function setMvvm(e) {
            $studentViewModel = kendo.observable({
                Id: e.Id,
                Name: e.Name,
                Address: e.Address,
                Phone: e.Phone,
                Email: e.Email,
                Dob: e.Dob,
                IsVisibleSave: e.IsVisibleSave,
                IsVisibleUpdate: e.IsVisibleUpdate,
                IsVisibleDelete: e.IsVisibleDelete,
                Insert: function (p) {
                    var validator = $("#_frmStudent").kendoValidator().data("kendoValidator");
                    if (!validator.validate()) {
                        return;
                    }
                    swal({
                        title: "Are you sure?",
                        text: "Do you want to insert recode!",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Yes!",
                        showLoaderOnConfirm: true,
                        closeOnConfirm: false
                    }, function () {
                        apiCalls.insert_(p.data).done(function (e) {
                            dsRefresh(Enums.Crud.insert, { Id: e, Name: p.data.Name, Email: p.data.Email });
                            swal("Inserted!", "", "success");
                            $("#frmStudent").modal('hide');
                        }).fail(function (e) {
                            Errors.handleErrors(e);
                        });
                    });
                },
                Update: function (p) {
                    var validator = $("#_frmStudent").kendoValidator().data("kendoValidator");
                    if (!validator.validate()) {
                        return;
                    }
                    swal({
                        title: "Are you sure?",
                        text: "Do you want to update recode!",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Yes!",
                        showLoaderOnConfirm: true,
                        closeOnConfirm: false
                    }, function () {
                        apiCalls.update_(p.data).done(function (e) {
                            dsRefresh(Enums.Crud.update, { Id: p.data.Id, Name: p.data.Name, Email: p.data.Email });
                            swal("Updated!", "", "success");
                            $("#frmStudent").modal('hide');
                        }).fail(function (e) {
                            Errors.handleErrors(e);
                        });
                    });
                },
                Delete: function (p) {
                    swal({
                        title: "Are you sure?",
                        text: "Do you want to delete recode!",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Yes!",
                        showLoaderOnConfirm: true,
                        closeOnConfirm: false
                    }, function () {
                        apiCalls.delete_({ Id: p.data.Id }).done(function (e) {
                            dsRefresh(Enums.Crud.delete, p.data.Id);
                            swal("Deleted!", "", "success");
                            $("#frmStudent").modal('hide');
                        }).fail(function (e) {
                            Errors.handleErrors(e);
                        });
                    });
                }
            });
        }
        function ModelOpen(e) {
            setMvvm(e);
            kendo.bind($("#frmStudent"), $studentViewModel);
            $("#frmStudent").modal('show').appendTo('body');
        }
        //datasource
        function dsRefresh(e, d) {
            if (e == Enums.Crud.read) {
                apiCalls.get_().done(function (e) {
                    dsStudents.data(e);
                    $('#gv-student').data("kendoGrid").setDataSource(dsStudents);
                }).fail(function (e) {
                    Errors.handleErrors(e);
                });
            }
            else if (e == Enums.Crud.insert) {
                dsStudents.add({ Id: d.Id, Name: d.Name, Email: d.Email });
            }
            else if (e == Enums.Crud.update) {
                $.each(dsStudents.data(), function (i, x) {
                    if (x.Id === d.Id) {
                        x.Name = d.Name;
                        x.Email = d.Email;
                    }
                });
            }
            else if (e == Enums.Crud.delete) {
                $.each(dsStudents.data(), function (i, x) {
                    if (x.Id === d) {
                        dsStudents.remove(dsStudents.at(i));
                    }
                });
            }
            $('#gv-student').data('kendoGrid').refresh();
        }
        function validation() {
            $("#_frmStudent").kendoValidator({
                rules: {
                    customRule1: function (input) {
                        if (input.is("[name='txtName']")) {
                            return $.trim(input.val()) !== "";
                        }
                        return true;
                    },
                    customRule2: function (input) {
                        if (input.is("[name='txtEmail']")) {
                            return $.trim(input.val()) !== "";
                        }
                        return true;
                    },
                    customRule3: function (input) {
                        if (input.is("[name='txtPhone']")) {
                            if (input.val().length != 10) {
                                return false;
                            }
                        }
                        return true;
                    },
                    customRule4: function (input) {
                        if (input.is("[name='txtAddress']")) {
                            if (input.is("[name='txtAddress']")) {
                                return $.trim(input.val()) !== "";
                            }
                        }
                        return true;
                    },
                },
                messages: {
                    customRule1: "Student name requred.",
                    customRule2: "Student Email requred.",
                    customRule3: "invalied phone number",
                    customRule4: "Student Address requred."
                }
            });
        }
        //public method
        return {
            init: function () {
                $("#main-placeHolder").html($("#template-student").html());
                $('#btnCreateStudentModelOpen').off().bind('click', null, function () {
                    var e = new MVVM.Student();
                    e.Id = 0;
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
                                        var data = this.dataItem($(e.target).closest("tr"));
                                        getSingle_(data.Id).done(function (e) {
                                            e.IsVisibleSave = false;
                                            e.IsVisibleUpdate = true;
                                            e.IsVisibleDelete = true;
                                            ModelOpen(e);
                                        }).fail(function (e) {
                                            Errors.handleErrors(e);
                                        });
                                    }
                                }]
                        }
                    ],
                });
                $('#dtStudentDob').kendoDatePicker();
                dsRefresh(Enums.Crud.read);
                validation();
            },
            studentDs: function () {
                return dsStudents.view();
            }
        };
    });
    $(function () { student().init(); });
})(One || (One = {}));
//# sourceMappingURL=app.js.map