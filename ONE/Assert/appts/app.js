var One;
(function (One) {
    var student = (function () {
        //globle variables
        var pageSize = 0;
        var dsStudents = new kendo.data.DataSource({
            pageSize: pageSize,
        });
        var url = "/api/v1/students";
        var $studentViewModel = new kendo.data.ObservableObject();
        var $lookupViewModel = new kendo.data.ObservableObject();
        //api calls
        var apiCalls = {
            lookup_: function () {
                return $.ajax({
                    url: url + '/lookup',
                    contentType: "application/json;charset=utf-8",
                    method: 'get',
                    data: null
                });
            },
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
                    url: url + '/' + e.Id,
                    contentType: "application/json;charset=utf-8",
                    method: 'put',
                    data: JSON.stringify(e)
                });
            },
            delete_: function (e) {
                return $.ajax({
                    url: url + '/' + e.Id,
                    contentType: "application/json;charset=utf-8",
                    method: 'post',
                    data: null
                });
            },
            get_: function (e) {
                return $.ajax({
                    url: url,
                    method: 'get',
                    contentType: "application/json;charset=utf-8",
                    data: e
                });
            },
            getSingle_: function (e) {
                return $.ajax({
                    url: url + "/" + e,
                    method: 'get',
                    contentType: "application/json;charset=utf-8",
                    data: null
                });
            }
        };
        // mvvm
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
                StreemId: e.StreemId.toString(),
                SchoolId: e.SchoolId.toString(),
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
                apiCalls.get_(d).done(function (e) {
                    dsStudents.data(e.result);
                    $('#recodeCount').val(d.recodeCount);
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
        //get
        function read(e) {
            dsRefresh(Enums.Crud.read, e);
        }
        //lookup datasource
        function lookup() {
            apiCalls.lookup_().done(function (e) {
                $lookupViewModel = kendo.observable({
                    streemDs: e.steem,
                    schoolDs: e.school
                });
                kendo.bind($("#frmStudent"), $lookupViewModel);
            }).fail(function (e) {
                Errors.handleErrors(e);
            });
        }
        function initControllers() {
            $("#main-placeHolder").html($("#template-student").html());
            $('#btnCreateStudentModelOpen').off('click').bind('click', null, function () {
                var e = new MVVM.Student();
                e.Id = 0;
                e.Dob = Util.addDays(new Date(), -5);
                e.IsVisibleSave = true;
                e.IsVisibleUpdate = false;
                e.IsVisibleDelete = false;
                e.SchoolId = 1;
                e.StreemId = 1;
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
                                    apiCalls.getSingle_(data.Id).done(function (e) {
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
                sortable: true,
                pageable: true,
                filterable: true
            });
            read(new utilBean.GetQuery(0, pageSize, 'id', false, ''));
            $('#btnSearch').off('click').on('click', function () {
                read(new utilBean.GetQuery(0, pageSize, 'id', false, $.trim($('#txtSearch').val())));
            });
            validation();
        }
        //public method
        return {
            init: function () {
                initControllers();
                lookup();
            },
            studentDs: function () {
                return dsStudents.view();
            }
        };
    });
    $(function () { student().init(); });
})(One || (One = {}));
//# sourceMappingURL=app.js.map