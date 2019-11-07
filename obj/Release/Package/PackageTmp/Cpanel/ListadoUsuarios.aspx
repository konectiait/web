<%@ Page Title="" Language="C#" MasterPageFile="~/Cpanel/Principal.Master" AutoEventWireup="true" CodeBehind="ListadoUsuarios.aspx.cs" Inherits="MundoCanjeWeb.Cpanel.ListadoUsuarios" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentBeginAndEndHandler" runat="server">
    <script type="text/javascript" language="javascript">
        function BeginRequestHandler() {
            //Antes de ejecutar la peticion de AJAX ASP.Net                      
        }
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() == undefined) {
                if ($("[id$=HdnIdUsuario]").val() == "0") {
                    $("#myModalABM").modal('hide');
                }
                //$('#example1').DataTable();
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="CphBody" runat="server">
    <asp:HiddenField ID="HdnIdUsuario" runat="server" Value="0" />
    <asp:HiddenField ID="HdnEsNuevo" runat="server" Value="0" />
    
          <div class="content-wrapper">
            
            <div class="page-header">
              <h3 class="page-title">
                <span class="page-title-icon bg-gradient-primary text-white mr-2">
                  <i class="mdi mdi-home"></i>
                </span> Comercios </h3>
              
            </div>
            <div class="row">
              <div class="col-md-4 stretch-card grid-margin">
                <div class="card bg-gradient-danger card-img-holder text-white">
                  <div class="card-body">
                    <img src="assets/images/dashboard/circle.svg" class="card-img-absolute" alt="circle-image" />
                    <h4 class="font-weight-normal mb-3">Comercios Totales <i class="mdi mdi-chart-line mdi-24px float-right"></i>
                    </h4>
                    <h2 class="mb-1">152</h2>
        
                  </div>
                </div>
              </div>
                <div class="col-md-4 stretch-card grid-margin">
                    <div class="card bg-gradient-info card-img-holder text-white">
                      <div class="card-body">
                        <img src="assets/images/dashboard/circle.svg" class="card-img-absolute" alt="circle-image" />
                        <h4 class="font-weight-normal mb-3">Canjes de Comercios <i class="mdi mdi-bookmark-outline mdi-24px float-right"></i>
                        </h4>
                        <h2 class="mb-1">50</h2>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 stretch-card grid-margin">
                    <div class="card bg-gradient-success card-img-holder text-white">
                      <div class="card-body">
                        <img src="assets/images/dashboard/circle.svg" class="card-img-absolute" alt="circle-image" />
                        <h4 class="font-weight-normal mb-3">Cupones de Comercios <i class="mdi mdi-diamond mdi-24px float-right"></i>
                        </h4>
                        <h2 class="mb-1">68</h2>
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
                              <h4 class="card-title">Listado de Comercios</h4>
                          </div>
                          <div class="col-4 text-right">
                              <button type="button" onclick='NuevoRegistro();return false' class="btn btn-gradient-info btn-icon-text"> Nuevo Comercio <i class="mdi mdi-folder-plus btn-icon-append"></i></button>
                          </div>
                       </div>
                    
                      
                    <div class="table-responsive">
                      <table class="table">
                        <thead>
                          <tr>
                            <th> Id </th>
                            <th> Usuario </th>
                            <th> Estado </th>
                            <th> Plan </th>
                            <th> Acciones </th>
                          </tr>
                        </thead>
                        <tbody>
                          
                            <asp:Literal ID="LitComercios" runat="server"></asp:Literal>
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
       
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title"><i class="fa fa-pencil"></i> Edición del Comercio: <asp:Label ID="LblIdUsuario" runat="server" Text="0"></asp:Label></h4>
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
                        <label class="control-label col-md-12 col-sm-12 col-xs-12">Telefono</label>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="Telefono" ID="TXbTelefono" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="form-group">
                        <label class="control-label col-md-12 col-sm-12 col-xs-12">E-Mail</label>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="E-Mail" ID="TXbMail" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="form-group">
                        <label class="control-label col-md-12 col-sm-12 col-xs-12">Dirección</label>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="Direccion" ID="TxbDireccion" runat="server" MaxLength="150"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="form-group">
                        <label class="control-label col-md-12 col-sm-12 col-xs-12">Estado</label>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="Estado" ID="TxbEstado" runat="server" MaxLength="150"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="form-group">
                        <label class="control-label col-md-12 col-sm-12 col-xs-12">Plan</label>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:TextBox class="form-control" ClientIDMode="Static" placeholder="Plan" ID="TxbPlan" runat="server" MaxLength="150"></asp:TextBox>
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
                <button type="button" ID="BtnAceptar" class="btn btn-primary" onclick="GrabarComercio(); return false" >Aceptar</button>
                <%--<asp:Button ID="BtnAceptar" class="btn btn-primary" runat="server" Text="Aceptar" OnClientClick="GrabarComercio(); return false"  />   --%>             
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
                url: "/api/image/SaveImage/Usuarios",
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

        function NuevoRegistro() {
            $("[id$=HdnEsNuevo]").val('1');
            $("#myModalABM").modal('show');
        }
        function SetDeleteId(id) {
            $("[id$=HdnIdUsuario]").val(id);
            $("#modalDelete").modal('show');
        }

        function GetEditId(id) {
            $("[id$=HdnIdUsuario]").val(id);
            $.ajax({
                type: "POST",
                url: "ListadoUsuarios.aspx/IniModalEdit",
                data: "{Id:'" + id + "'}",
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var ListaMC = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    if (ListaMC.Result[0] == null) {
                        //alert('No exiten datos');                        
                        $("[id$=HdnIdUsuario]").val(0);
                        $("[id$=LblIdUsuario]").text(0);
                        $("#TxbNombre").val('');
                        $("#TxbDireccion").val('');  
                        $("#TXbTelefono").val('');  
                        $("#TXbMail").val('');  
                        $("#TxbEstado").val('');  
                        $("#TxbPlan").val('');  
                        $("#TxbImagen").val('');
                        $("#myModalABM").modal('show');

                    }
                    else {
                        $("[id$=LblIdUsuario]").text(ListaMC.Result[0].Id);
                        $("#TxbNombre").val(ListaMC.Result[0].Nombre);
                        $("#TxbDireccion").val(ListaMC.Result[0].Direccion);
                        $("#TXbTelefono").val(ListaMC.Result[0].Telefono);
                        $("#TXbMail").val(ListaMC.Result[0].Mail);
                        $("#TxbEstado").val(ListaMC.Result[0].Cuit);
                        $("#TxbPlan").val(ListaMC.Result[0].IdPlan);                        
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
        function GrabarComercio() {
            var vId = $("[id$=HdnIdUsuario]").val();
            var vNombre = $("#TxbNombre").val();
            var vDireccion = $("#TxbDireccion").val();
            var vTel = $("#TXbTelefono").val();
            var vMail = $("#TXbMail").val();
            var vEstado = $("#TxbEstado").val();
            var vPlan = $("#TxbPlan").val();
            var vImagen = $("#myUploadedImg").attr("src");
            var EsNuevo = $("[id$=HdnEsNuevo]").val();
            var vToken = "";
            var vIdTipo = 1;
            var vLat = "";
            var vLong = "";
            var vPuntuacion = 0;

            var local = { Id: vId, Nombre: vNombre, Telefono: vTel, Mail: vMail, Direccion: vDireccion, token: vToken, Estado: vIdEstado, IdTipo: vIdTipo, Plan: vPlan, Lat: vLat, Long: vLong, Puntuacion: vPuntuacion, Imagen: vImagen};

            $.ajax({
                type: "POST",
                url: "ListadoUsuarios.aspx/Grabar",
                //data: JSON.stringify({ 'Nombre': vNombre, 'Direccion': vDireccion, 'Telefono': vTel, 'Mail': vMail, 'Cuit': vEstado, 'RazonSocial': vPlan, 'Imagen': vImagen, 'EsNuevo': EsNuevo }),

                data: JSON.stringify({ 'usuario': local, 'EsNuevo': EsNuevo }),                
                //data: JSON.stringify({ 'EsNuevo': EsNuevo }),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    if (resp == 1) {
                        $('#myModalABM').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();
                        //RefrescarUpdatePanel();
                        window.location.href = "ListadoUsuarios.aspx";
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
            var vId = $("[id$=HdnIdUsuario]").val();
            $.ajax({
                type: "POST",
                url: "ListadoUsuarios.aspx/Eliminar",
                data: JSON.stringify({ 'idComercio': vId }),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var resp = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    if (resp == 1) {
                        $('#modalDelete').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();
                        //RefrescarUpdatePanel();
                        window.location.href = "ListadoUsuarios.aspx";
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
