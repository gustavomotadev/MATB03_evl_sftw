<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BugFeed.Default" Title="Página Inicial" %>
<%@ Import Namespace="BugFeed.Objects.Extensions" %>
<!DOCTYPE html>
<html lang="pt-BR">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title><%: Page.Title %> - BugFeed</title>
  <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
  <link rel="stylesheet" type="text/css" href="/assets/lib/material-design-icons/css/material-design-iconic-font.min.css">
  <link rel="stylesheet" type="text/css" href="/assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css">
  <link rel="stylesheet" type="text/css" href="/assets/lib/datetimepicker/css/bootstrap-datetimepicker.min.css">
  <link rel="stylesheet" type="text/css" href="/assets/lib/select2/css/select2.min.css">
  <link rel="stylesheet" type="text/css" href="/assets/lib/bootstrap-slider/css/bootstrap-slider.min.css">
  <!--[if lt IE 9]>
	  <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
	  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
  <link rel="stylesheet" href="/assets/lib/bootstrap/css/bootstrap.min.css" type="text/css">
  <link rel="stylesheet" href="/assets/lib/summernote/summernote-bs4.css" type="text/css" />
  <link rel="stylesheet" href="/assets/css/app.css" type="text/css">
  <link rel="stylesheet" href="/assets/css/main.css" type="text/css">
</head>

<body runat="server" id="body">
  <div class="be-wrapper be-nosidebar-left home-container">
    <nav class="navbar navbar-expand fixed-top be-top-header">
      <div class="container">

        <!-- Navbar Header -->
        <div class="be-navbar-header">



          <!-- Brand Logo -->
          <a href="/" class="navbar-brand"></a>
        </div>

        <div class="be-right-navbar">
          <ul class="nav navbar-nav float-right" id="loggedOutMenu" runat="server">
            <li class="nav-item"><a href="/Account/SignIn.aspx" class="nav-link">Fazer login</a></li>
          </ul>

          <ul class="nav navbar-nav float-right be-user-nav" id="loggedInMenu" runat="server" visible="false">
            <li class="nav-item dropdown">
              <a href="#" data-toggle="dropdown" role="button" aria-expanded="false" class="nav-link dropdown-toggle">
                <img src="<%: this.GetGravatarUrl(32) %>" alt="Avatar"><span class="user-name" ><%: Session["NomeSobrenome"] %></span></a>
              <div role="menu" class="dropdown-menu">
                <div class="user-info">
                  <div class="user-name"><%: Session["NomeSobrenome"] %></div>
                </div>
                <a href="/Dashboard/" class="dropdown-item">
                  <span class="icon mdi mdi-home"></span>Dashboard
                </a>
                <a href="#" class="dropdown-item">
                  <span class="icon mdi mdi-face"></span>Perfil
                </a>
                <a href="#" class="dropdown-item">
                  <span class="icon mdi mdi-settings"></span>Configurações
                </a>
                <a href="/Account/SignOut.aspx" class="dropdown-item">
                  <span class="icon mdi mdi-power"></span>Sair
                </a>
              </div>
            </li>
          </ul>
        </div>

        <div id="be-navbar-collapse" class="navbar-collapse collapse">
          <!-- Default bootstrap navbar -->
        </div>

      </div>
    </nav>
    <div class="be-content">
      <div class="container text-center">
        <div class="row">
          <div class="col-12">
            <p class="featured-title">Uma plataforma de recompensas por bugs de segurança</p>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <p class="featured-subtitle">A ponte entre pesquisadores de segurança e empresas que oferecem produtos e serviços online.</p>
          </div>
        </div>
        <div class="row home-buttons">
          <div class="col-6 text-right">
            <a href="SignUp/Business.aspx">Iniciar como empresa</a>
          </div>
          <div class="col-6 text-left">
            <a href="SignUp/User.aspx">Iniciar como pesquisador</a>
          </div>
        </div>
      </div>
    </div>
  </div>
  <script src="/assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
  <script src="/assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
  <script src="/assets/lib/bootstrap/js/bootstrap.bundle.min.js" type="text/javascript"></script>
  <script src="/assets/lib/jquery.maskedinput/jquery.maskedinput.js" type="text/javascript"></script>
  <script src="/assets/lib/select2/js/select2.min.js" type="text/javascript"></script>
  <script src="/assets/lib/datetimepicker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
  <script src="/assets/lib/bootstrap-slider/bootstrap-slider.min.js" type="text/javascript"></script>
  <script src="/assets/lib/summernote/summernote-bs4.js" type="text/javascript"></script>
  <script src="/assets/lib/summernote/summernote-ext-beagle.js" type="text/javascript"></script>
  <script src="/assets/lib/fuelux/js/fuelux.min.js"></script>
  <script src="/assets/js/app.js" type="text/javascript"></script>
  <script src="/assets/js/main.js" type="text/javascript"></script>
</body>
</html>
