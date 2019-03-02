<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExperienceValidator.aspx.cs" Inherits="SXV.Feature.Validator.sitecore.shell.Applications.ExperienceValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Experience Validator</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="jumbotron" style="padding: 1rem !important;">
                <h1 class="display-4">Sitecore Experience Validator</h1>
                <p class="lead">The Sitecore Experience Validator (SxV) is a tool which runs few checks for validating configuration of your sitecore instance allowing you to measure for enablement of Sitecore Experience Analytics</p>
                <hr class="my-4" />
            </div>

            <div class="accordion" id="accordionExample">
                <div class="card">
                    <div class="card-header" id="headingOne">
                        <h2 class="mb-0">
                            <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                Validate Configuration
                            </button>
                        </h2>
                    </div>
                    <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                        <div class="card-body">

                            <button style="margin-bottom: 10px;" runat="server" id="RunConfiguration" class="btn btn-outline-secondary" type="button" onserverclick="RunConfiguration_Click">Run Validator</button>
                            <div id="divPanelButtons" runat="server">
                                <p>
                                    <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#multiCollapseExample1" aria-expanded="false" aria-controls="multiCollapseExample1">xDB</button>
                                    <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#multiCollapseExample2" aria-expanded="false" aria-controls="multiCollapseExample2">Database</button>
                                    <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#multiCollapseExample3" aria-expanded="false" aria-controls="multiCollapseExample3">Configurations</button>
                                    <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#multiCollapseExample4" aria-expanded="false" aria-controls="multiCollapseExample4">Search Provider & Indexes</button>
                                    <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#multiCollapseExample5" aria-expanded="false" aria-controls="multiCollapseExample5">Content Testing</button>
                                    <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#multiCollapseExample6" aria-expanded="false" aria-controls="multiCollapseExample6">Miscellaneous</button>
                                </p>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="collapse multi-collapse" id="multiCollapseExample1">
                                        <div class="card card-body">
                                            <h5 class="modal-title">xDB Information</h5>
                                            <div class="alert alert-<%=IsxDBEnabled %>" role="alert">
                                                <asp:Label ID="lblxDBsettings" runat="server"></asp:Label>
                                            </div>
                                            <div class="alert alert-<%=IsTrackingEnabled %>" role="alert">
                                                <asp:Label ID="lblTrackingEnabled" runat="server"></asp:Label>
                                            </div>
                                            <div class="alert alert-<%=IsxDBLicense %>" role="alert">
                                                <asp:Label ID="lblxDBLicense" runat="server"></asp:Label>
                                            </div>
                                            <div class="alert alert-success" role="alert">
                                                Definition database is:
                                                <asp:Label ID="lblDefaultDefinitionDatabase" runat="server"></asp:Label>
                                            </div>
                                            <div class="alert alert-<%=IsXConnect %>" role="alert">
                                                <asp:Label ID="lblxConnect" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="collapse multi-collapse" id="multiCollapseExample2">
                                        <div class="card card-body">
                                            <h5 class="modal-title">Database Information</h5>
                                            <% if (configurationModel.AvailableConnectionStrings != null && configurationModel.AvailableConnectionStrings.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of Available Connection Strings</strong><br />
                                                <asp:Label ID="lblDBConnectionString" runat="server"></asp:Label>
                                            </div>
                                            <%}%>
                                            <% if (configurationModel.UnavailableConnectionStrings != null && configurationModel.UnavailableConnectionStrings.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of UnAvailable Connection Strings</strong><br />
                                                <asp:Label ID="lblUnDBConnectionString" runat="server"></asp:Label>
                                            </div>
                                            <%}%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="collapse multi-collapse" id="multiCollapseExample3">
                                        <div class="card card-body">
                                            <h5 class="modal-title">Config Files</h5>
                                            <% if (configurationModel.XdbEnabledConfigs != null && configurationModel.XdbEnabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of xDB config files which are enabled: </strong>
                                                <br />
                                                <asp:Label ID="lblXdbEnabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                            <% if (configurationModel.XdbDisabledConfigs != null && configurationModel.XdbDisabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-danger" role="alert">
                                                <strong>List of xDB config files which are disabled:</strong><br />
                                                <asp:Label ID="lblXdbDisabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                            <% if (configurationModel.TrackingEnabledConfigs != null && configurationModel.TrackingEnabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of Tracking config files which are enabled:</strong><br />
                                                <asp:Label ID="lblTrackingEnabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                            <% if (configurationModel.TrackingDisabledConfigs != null && configurationModel.TrackingDisabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-danger" role="alert">
                                                <strong>List of Tracking config files which are disabled: </strong>
                                                <br />
                                                <asp:Label ID="lblTrackingDisabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                            <% if (configurationModel.ExperienceAnalyticsEnabledConfigs != null && configurationModel.ExperienceAnalyticsEnabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of Experience Analytics config files which are enabled: </strong>
                                                <br />
                                                <asp:Label ID="lblExperienceAnalyticsEnabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                            <% if (configurationModel.ExperienceAnalyticsDisabledConfigs != null && configurationModel.ExperienceAnalyticsDisabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-danger" role="alert">
                                                <strong>List of Experience Analytics config files which are disabled: </strong>
                                                <br />
                                                <asp:Label ID="lblExperienceAnalyticsDisabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="collapse multi-collapse" id="multiCollapseExample4">
                                        <div class="card card-body">
                                            <h5 class="modal-title">Search & Indexes</h5>
                                            <div class="alert alert-<%=IsSolrRunning %>" role="alert">
                                                <asp:Label ID="lblSolrRunning" runat="server"></asp:Label>
                                            </div>
                                            <% if (configurationModel.AvailableIndexes != null && configurationModel.AvailableIndexes.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of Experience Available Indexes: </strong>
                                                <br />
                                                <asp:Label ID="lblAvailableIndexes" runat="server"></asp:Label>
                                            </div>
                                            <%}%>
                                            <% if (configurationModel.UnavailableIndexes != null && configurationModel.UnavailableIndexes.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of Experience UnAvailable Indexes: </strong>
                                                <br />
                                                <asp:Label ID="lblUnAvailableIndexes" runat="server"></asp:Label>
                                            </div>
                                            <%}%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="collapse multi-collapse" id="multiCollapseExample5">
                                        <div class="card card-body">
                                            <h5 class="modal-title">Content Testing</h5>
                                            <div class="alert alert-<%=IsContentTestingEnabled %>" role="alert">
                                                <asp:Label ID="lblContentTestingEnabled" runat="server"></asp:Label>
                                            </div>
                                            <% if (configurationModel.ContentTestingEnabledConfigs != null && configurationModel.ContentTestingEnabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-success" role="alert">
                                                <strong>List of Content Testing config files which are enabled:</strong>
                                                <br />
                                                <asp:Label ID="lblContentTestingEnabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                            <% if (configurationModel.ContentTestingDisabledConfigs != null && configurationModel.ContentTestingDisabledConfigs.Any())
                                                { %>
                                            <div class="alert alert-danger" role="alert">
                                                <strong>List of Content Testing config files which are disabled:</strong><br />
                                                <asp:Label ID="lblContentTestingDisabledConfigs" runat="server"></asp:Label>
                                            </div>
                                            <% } %>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="collapse multi-collapse" id="multiCollapseExample6">
                                        <div class="card card-body">
                                            <h5 class="modal-title">Miscellaneous</h5>
                                            <div class="alert alert-<%=GlobalAsaxExist %>" role="alert">
                                                <asp:Label ID="lblGlobalAsax" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" id="headingTwo">
                        <h2 class="mb-0">
                            <button runat="server" class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                Page with Personalization
                            </button>

                        </h2>
                    </div>
                    <div id="collapseTwo" class="collapse show" aria-labelledby="headingTwo" data-parent="#accordionExample">
                        <div class="card-body">
                            
                                
                                    <button runat="server" id="btnGetPersonalization" onserverclick="btnGetPersonalization_ServerClick" class="btn btn-outline-secondary" type="button">Get It!</button>
                                    </div>
                                    <div style="margin-left:10px">
                                        <p>
                                            <asp:Label ID="personalizedData" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                
                            
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
