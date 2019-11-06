﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cpanel/Principal.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="MundoCanjeWeb.Cpanel.Categorias" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentBeginAndEndHandler" runat="server">
    <script type="text/javascript" language="javascript">
        function BeginRequestHandler() {
            //Antes de ejecutar la peticion de AJAX ASP.Net                      
        }
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() == undefined) {
                if ($("[id$=HdnIdCategoria]").val() == "0") {
                    $("#myModalABM").modal('hide');
                }
                //$('#example1').DataTable();
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="CphBody" runat="server">
    <asp:HiddenField ID="HdnIdCategoria" runat="server" Value="0" />
    <asp:HiddenField ID="HdnEsNuevaCat" runat="server" Value="0" />
    
          <div class="content-wrapper">
            
            <div class="page-header">
              <h3 class="page-title">
                <span class="page-title-icon bg-gradient-primary text-white mr-2">
                  <i class="mdi mdi-home"></i>
                </span> Categorias </h3>
              
            </div>
            <div class="row">
              <div class="col-md-4 stretch-card grid-margin">
                <div class="card bg-gradient-danger card-img-holder text-white">
                  <div class="card-body">
                    <img src="assets/images/dashboard/circle.svg" class="card-img-absolute" alt="circle-image" />
                    <h4 class="font-weight-normal mb-3">Categorias Totales <i class="mdi mdi-chart-line mdi-24px float-right"></i>
                    </h4>
                    <h2 class="mb-1">15</h2>
        
                  </div>
                </div>
              </div>
              
            </div>
            <div class="row">
              <div class="col-12 grid-margin">
                <div class="card">
                  <div class="card-body">
                      <div class="row">
                          <div class="col-8">
                              <h4 class="card-title">Listado de Categorías</h4>
                          </div>
                          <div class="col-4 text-right">
                              <button type="button" onclick='NuevaCategoria();return false' class="btn btn-gradient-info btn-icon-text"> Nueva Categoría <i class="mdi mdi-folder-plus btn-icon-append"></i></button>
                          </div>
                       </div>
                    
                      
                    <div class="table-responsive">
                      <table class="table">
                        <thead>
                          <tr>
                            <th> Id </th>
                            <th> Nombre </th>
                            <th> Imagen </th>
                            <th> Acciones </th>
                          </tr>
                        </thead>
                        <tbody>
                          <%--<tr>
                              <td> 1 </td>
                              <td> Moda </td>   
                            <td>
                              <img src="http://localhost:51199/Imagenes/Categorias/ca5.png" style="width:200px !important;border-radius:0px !important;height: auto !important;" >

                            </td>
                            <td style="font-size: x-large"> 
                                <a id="BtnEdit" href="#" >
                                <i class="mdi mdi-lead-pencil"></i>
                                    <span class="count-symbol bg-warning"></span>
                                </a>
                                <a id="BtnRemove" href="#" >
                                <i class="mdi mdi-delete-outline"></i>
                                    <span class="count-symbol bg-warning"></span>
                                </a>
                            </td>                           
                            
                            
                          </tr>--%>
                            <asp:Literal ID="LitCategorias" runat="server"></asp:Literal>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            
          </div>
          
    
    <div class="modal fade" id="myModalABM"  data-backdrop="static"  data-keyboard="false" aria-hidden="true" role="dialog">    
        <div class="modal-dialog">
        <div class="modal-content">
            <%--<div class="modal-header">
                <div class="form-group">                     
                            <h4 class="modal-title"><i class="fa fa-pencil"></i> Edición de la Categoria: 
                                <asp:Label ID="LblIdCategoria" runat="server" Text="0"></asp:Label>
                            </h4>
                    <div class="text-right">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                               <span aria-hidden="true">&times;</span>
                           </button>
                    </div>      
                   
                </div>                
            </div>--%>
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title"><i class="fa fa-pencil"></i> Edición de Categoria: <asp:Label ID="LblIdCategoria" runat="server" Text="0"></asp:Label></h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal form-label-left">                    
                    <div class="form-group">
                        <label class="control-label col-md-12 col-sm-12 col-xs-12">Nombre</label>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="Nombre" ID="TxbNombre" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>                    
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Imagen</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">                                                
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="Ruta Imagen" ID="TxbImagen" runat="server"></asp:TextBox>
                            <img id="myUploadedImg" alt="Imagen" style="width:100px;" />
                            <br />
                            <input type="file" class="upload"  id="f_UploadImage">                            
                        </div>                        
                    </div>                      
                </div>
            </div>
            <div class="modal-footer">                
                <button type="button" ID="BtnCancelar" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                <asp:Button ID="BtnAceptar" class="btn btn-primary" runat="server" Text="Aceptar" OnClientClick="GrabarCategoria(); return false"  />                
            </div>
        </div>
        <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <div class="modal fade" id="modalDelete" style="display: none;">
          <div class="modal-dialog">
            <div class="modal-content" style="width: 70%;">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">×</span></button>
                <h4 class="modal-title">Confirmar Eliminación</h4>
              </div>
              <div class="modal-body">
                <p>¿Está seguro de eliminar el registro?</p>
              </div>
              <div class="modal-footer">
                <button type="button" onclick='DeleteById();return false' class="btn btn-primary">Si</button>
                  <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphJsInferior" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            console.log("ready!");
            

        });

        var _URL = window.URL || window.webkitURL;
        $("#f_UploadImage").on('change', function () {            
            var data = new FormData();
            var files = $("#f_UploadImage").get(0).files;
            console.log("El file es: " + files);

            if (files.length > 0) {
                data.append("UploadedImage", files[0]);
            }
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "/api/image/CategoryImage",
                contentType: false,
                processData: false,
                data: data
            });

            ajaxRequest.done(function (xhr, textStatus) {
                // Do other operation
                console.log("OK");
                $("#myUploadedImg").attr("src", xhr.Message);
            });
            ajaxRequest.fail(function () {
                console.log("Error al devolver el POST");
            });
        });

        function NuevaCategoria() {
            $("[id$=HdnEsNuevaCat]").val('1');
            $("#myModalABM").modal('show');
        }
        function SetDeleteId(id) {
            $("[id$=HdnIdCategoria]").val(id);
            $("#modalDelete").modal('show');
        }

        function GetEditId(id) {
            $("[id$=HdnIdCategoria]").val(id);
            $.ajax({
                type: "POST",
                url: "Categorias.aspx/IniModalEdit",
                data: "{Id:'" + id + "'}",
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var ListaMC = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    if (ListaMC.Result[0] == null) {
                        //alert('No exiten datos');                        
                        $("[id$=HdnIdCategoria]").val(0);
                        $("[id$=LblIdCategoria]").text(0);
                        $("#TxbNombre").val('');
                        $("#TxbImagen").val('');
                        $("#myModalABM").modal('show');

                    }
                    else {
                        $("[id$=LblIdCategoria]").text(ListaMC.Result[0].Id);
                        $("#TxbNombre").val(ListaMC.Result[0].Nombre);
                        $("#TxbImagen").val(ListaMC.Result[0].Imagen);
                        $("#myUploadedImg").attr("src", ListaMC.Result[0].Imagen);
                        $("#myModalABM").modal('show');
                    }
                },
                error: function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                }
            });
        }
        function GrabarCategoria() {
            var vIdCat = $("[id$=HdnIdCategoria]").val();
            var vNombre = $("#TxbNombre").val();
            
            var vImagen = $("#myUploadedImg").attr("src");
            var EsNuevo = $("[id$=HdnEsNuevaCat]").val();

            var local = { Id: vIdCat, Nombre: vNombre, Imagen: vImagen };

            $.ajax({
                type: "POST",
                url: "Categorias.aspx/Grabar",
                data: JSON.stringify({ 'categ': local, 'EsNuevo': EsNuevo }),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    if (resp == 1) {
                        $('#myModalABM').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();
                        //RefrescarUpdatePanel();
                        window.location.href = "Categorias.aspx";
                    }
                    else {
                        AlertError();
                    }
                },
                error: function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                }
            });
        }

        function DeleteById() {
            var vIdCateg = $("[id$=HdnIdCategoria]").val();
            $.ajax({
                type: "POST",
                url: "Categorias.aspx/Eliminar",
                data: JSON.stringify({ 'idCategoria': vIdCateg }),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    if (resp == 1) {
                        $('#modalDelete').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();
                        //RefrescarUpdatePanel();
                        window.location.href = "Categorias.aspx";
                    }
                    else {
                        AlertError();
                    }
                },
                error: function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                }
            });
        }

      
    </script>
</asp:Content>
