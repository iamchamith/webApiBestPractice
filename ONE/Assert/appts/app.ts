module One {
    var student = (function () {
        //globle variables
        var pageSize = 0;
        let dsStudents = new kendo.data.DataSource({
        });
        let dsOrderList = new kendo.data.DataSource({
            pageSize: pageSize,
        });
        const url = "/api/v1/students";
        var $studentViewModel = new kendo.data.ObservableObject();
        var $lookupViewModel = new kendo.data.ObservableObject();
        //api calls
        var apiCalls = {
            lookup_(): JQueryXHR {
                try {
                    return $.ajax({
                        url: url + '/lookup',
                        contentType: "application/json;charset=utf-8",
                        method: 'get',
                        data: null
                    });
                } catch (err) { throw err; }
            },
            insert_(e: MVVM.Student): JQueryXHR {
                try {
                    return $.ajax({
                        url: url,
                        contentType: "application/json;charset=utf-8",
                        method: 'post',
                        data: JSON.stringify(e)
                    });
                } catch (err) { throw err; }
            },
            update_(e: MVVM.Student): JQueryXHR {
                try {
                    return $.ajax({
                        url: url + '/' + e.Id,
                        contentType: "application/json;charset=utf-8",
                        method: 'put',
                        data: JSON.stringify(e)
                    });
                } catch (err) { throw err; }
            },
            delete_(e: any): JQueryXHR {
                try {
                    return $.ajax({
                        url: url + '/' + e.Id,
                        contentType: "application/json;charset=utf-8",
                        method: 'post',
                        data: null
                    });
                } catch (err) { throw err; }
            },
            get_(e?: Util.Bean.GetQuery): JQueryXHR {
                try {
                    return $.ajax({
                        url: url,
                        method: 'get',
                        contentType: "application/json;charset=utf-8",
                        data: e
                    });
                } catch (err) { throw err; }
            },
            getSingle_(e: number): JQueryXHR {
                try {
                    return $.ajax({
                        url: url + "/" + e,
                        method: 'get',
                        contentType: "application/json;charset=utf-8",
                        data: null
                    });
                } catch (err) { throw err; }
            },
            ////// sortable list
            getOrderdList_(): JQueryXHR {
                try {
                    return $.ajax({
                        url: url + '/order',
                        method: 'get',
                        data: null
                    });
                } catch (err) { throw err; }
            },
            updateOrderdList_(e): JQueryXHR {
                try {
                    return $.ajax({
                        url: url + '/order',
                        method: 'post',
                        data: e
                    });
                } catch (err) { throw err; }
            }
        }
        // mvvm
        function setMvvm(e: MVVM.Student): void {
            try {
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
                    Insert: (p) => {
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
                        },
                            function () {
                                apiCalls.insert_(p.data).done((e) => {
                                    dsRefresh(Util.Enums.Crud.insert, { Id: e, Name: p.data.Name, Email: p.data.Email });
                                    swal("Inserted!", "", "success");
                                    $("#frmStudent").modal('hide');
                                }).fail((e) => {
                                    Util.Errors.handleErrors(e);
                                });
                            });

                    },
                    Update: (p) => {
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
                        },
                            function () {
                                apiCalls.update_(p.data).done((e) => {
                                    dsRefresh(Util.Enums.Crud.update, { Id: p.data.Id, Name: p.data.Name, Email: p.data.Email });
                                    swal("Updated!", "", "success");
                                    $("#frmStudent").modal('hide');
                                }).fail((e) => {
                                    Util.Errors.handleErrors(e);
                                });
                            });
                    },
                    Delete: (p) => {
                        swal({
                            title: "Are you sure?",
                            text: "Do you want to delete recode!",
                            type: "warning",
                            showCancelButton: true,
                            confirmButtonColor: "#DD6B55",
                            confirmButtonText: "Yes!",
                            showLoaderOnConfirm: true,
                            closeOnConfirm: false
                        },
                            function () {
                                apiCalls.delete_({ Id: p.data.Id }).done((e) => {
                                    dsRefresh(Util.Enums.Crud.delete, p.data.Id);
                                    swal("Deleted!", "", "success");
                                    $("#frmStudent").modal('hide');
                                }).fail((e) => {
                                    Util.Errors.handleErrors(e);
                                });
                            });
                    }
                });
            } catch (err) {
                throw err;
            }
        }
        function ModelOpen(e: MVVM.Student): void {
            try {
                setMvvm(e);
                kendo.bind($("#frmStudent"), $studentViewModel);
                $("#frmStudent").modal('show').appendTo('body');
            } catch (err) { throw err; }
        }
        //datasource
        function dsRefresh(e: Util.Enums.Crud, d?: any): void {
            try {
                if (e == Util.Enums.Crud.read) {
                    apiCalls.get_(d).done((e) => {
                        dsStudents.data(e.result);
                        $('#recodeCount').val(d.recodeCount);
                        $('#gv-student').data("kendoGrid").setDataSource(dsStudents);
                    }).fail((e) => {
                        Util.Errors.handleErrors(e);
                    });
                } else if (e == Util.Enums.Crud.insert) {
                    dsStudents.add({ Id: d.Id, Name: d.Name, Email: d.Email });
                } else if (e == Util.Enums.Crud.update) {
                    $.each(dsStudents.data(), (i, x) => {
                        if (x.Id === d.Id) {
                            x.Name = d.Name;
                            x.Email = d.Email;
                        }
                    });
                }
                else if (e == Util.Enums.Crud.delete) {
                    $.each(dsStudents.data(), (i, x) => {
                        if (x.Id === d) {
                            dsStudents.remove(dsStudents.at(i));
                        }
                    });
                }
                $('#gv-student').data('kendoGrid').refresh();
            } catch (err) { throw err; }
        }
        function validation() {
            try {
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
                            } return true;
                        },
                        customRule3: function (input) {
                            if (input.is("[name='txtPhone']")) {
                                if (input.val().length != 10) { return false; }
                            } return true;
                        },
                        customRule4: function (input) {
                            if (input.is("[name='txtAddress']")) {
                                if (input.is("[name='txtAddress']")) {
                                    return $.trim(input.val()) !== "";
                                }
                            } return true;
                        },
                    },
                    messages: {
                        customRule1: "Student name requred.",
                        customRule2: "Student Email requred.",
                        customRule3: "invalied phone number",
                        customRule4: "Student Address requred."
                    }
                });
            } catch (err) { throw err; }
        }

        //get
        function read(e) {
            try {
                dsRefresh(Util.Enums.Crud.read, e);
            } catch (err) { throw err; }
        }

        //lookup datasource
        function lookup() {
            try {
                apiCalls.lookup_().done((e) => {
                    $lookupViewModel = kendo.observable({
                        streemDs: e.steem,
                        schoolDs: e.school
                    });
                    kendo.bind($("#frmStudent"), $lookupViewModel);
                }).fail((e) => {
                    Util.Errors.handleErrors(e);
                });
            } catch (err) { throw err; }
        }

        // sortable
        function getOrderdList() {

            //getOrderdList
        }
        function viewOrderList(e) {
            if (e === 'show') {
                $('.crud').hide(500);
                $('.sort').show(500);
            } else {
                $('.sort').hide(500);
                $('.crud').show(500);
            }
        }

        function saveOrderList() { }

        function initControllers() {
            try {
                $("#main-placeHolder").html($("#template-student").html());
                $('#btnCreateStudentModelOpen').off('click').bind('click', null, () => {
                    var e = new MVVM.Student();
                    e.Id = 0;
                    e.Dob = Util.Tools.addDays(new Date(), -5);
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
                                    apiCalls.getSingle_(data.Id).done((e: MVVM.Student) => {
                                        e.IsVisibleSave = false;
                                        e.IsVisibleUpdate = true;
                                        e.IsVisibleDelete = true;
                                        ModelOpen(e);
                                    }).fail((e) => {
                                        Util.Errors.handleErrors(e);
                                    });

                                }
                            }]
                        }
                    ],
                    sortable: true,
                    pageable: true,
                    filterable: true
                });
                read(new Util.Bean.GetQuery(0, pageSize, 'id', false, ''));
                $('#btnSearch').off('click').on('click', () => {
                    read(new Util.Bean.GetQuery(0, pageSize, 'id', false, $.trim($('#txtSearch').val())));
                });
                $('#flImg').change((e) => {
                    var d: any = document.getElementById("flImg");
                    Util.Tools.encodeImageFileAsURL(d.files, (e) => {
                        $('#imgStudent').attr('src', e.f);
                    });
                });
                $('#btnOrderList').on('click', (e) => {
                    var $d = $(e.target);
                    viewOrderList($d.data('visible'));
                    if ($d.data('visible') === 'show') {
                        $d.data('visible', 'hide');
                        $d.val('Back to View');
                    } else {
                        $d.data('visible', 'show');
                        $d.val('Show Order List');
                    }
                });

                $("#sortable-basic").kendoSortable({
                    hint: function (element) {
                        return element.clone().addClass("hint");
                    },
                    placeholder: function (element) {
                        return element.clone().addClass("placeholder").text("drop here");
                    },
                    cursorOffset: {
                        top: -10,
                        left: -230
                    }
                });
                validation();
            } catch (err) { throw err; }
        }
        //public method
        return {
            init: (): void => {
                try {
                    initControllers();
                    lookup();
                } catch (err) {
                    Util.Errors.logException(err, "student");
                }
            },
            studentDs(): kendo.data.ObservableArray {
                return dsStudents.view();
            }
        };
    });
    $(document).ajaxStart(function () {
        $("#loading").show(100);
    });

    $(document).ajaxStop(function () {
        $("#loading").hide(1000)
    });
    $(() => { student().init(); });
}