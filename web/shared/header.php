<header>

<nav class="navbar navbar-expand-lg navbar-light bg-light justify-content-between">
  
  <div class="collapse navbar-collapse">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="welcome.php"><i class="fas fa-home"></i> Shifts</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="details.php"><i class="fas fa-info-circle"></i> Details</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="notify.php">  <i class="far fa-envelope"></i> Inform</a>
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