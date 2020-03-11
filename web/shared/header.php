<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">

    <!-- Bootstrap 4.0 CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

    <!-- JQuery 3.4.1 CDN -->
    <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
  
    <link rel="stylesheet" href="./css/header-page.css">
    <link rel="stylesheet" href="./css/welcome-page.css">
    
    <title>Header</title>
</head>
<body>

<header>

<nav class="navbar navbar-expand-lg navbar-light bg-light justify-content-between">
  
  <div class="collapse navbar-collapse">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="#"><i class="fas fa-home"></i> Home</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#"><i class="fas fa-info-circle"></i> Details</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#"> <i class="far fa-money-bill-alt"></i> Payments</a>
      </li>
    </ul>
  </div>
  <a class="nav-link disable"> Welcome <b><?php echo $_SESSION["fullname"] ?></b></a>
  <a  href="./includes/logout.php" class="btn btn-sm btn-outline-secondary">Sign out <i class="fas fa-sign-out-alt"></i> </a>
</nav>

</header>
