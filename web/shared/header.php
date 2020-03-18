<header>

<nav class="navbar navbar-expand-lg navbar-light bg-light justify-content-between">
  
  <div class="collapse navbar-collapse">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="welcome.php"><i class="fas fa-home "></i> Shifts</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="details.php"><i class="fas fa-info-circle faa-spin animated-hover"></i> Details</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="notify.php">  <i class="far fa-envelope "></i> Notifications</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="preferences.php"> <i class="fas fa-praying-hands"></i></i> Preferences</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="payments.php"> <i class="far fa-money-bill-alt"></i> Payments</a>
      </li>
      
    </ul>
  </div>
  <a class="nav-link disable" id="header-username"><?php echo $_SESSION["fullname"] ?></a>
  <a  href="./includes/logout.php" class="btn btn-sm btn-outline-secondary">Sign out <i class="fas fa-sign-out-alt"></i> </a>
</nav>

</header>