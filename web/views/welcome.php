<?php

// Starts a new session
session_start();

// Checks if the user is logged in, if not then redirect him to login page
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    header("location: ../index.php");
    exit;
}

// Adds the database configuration
require_once "../includes/config.inc.php";

// Adds the Shift model
require "../models/Shift.php";

// Library for the PDF
require_once  '../vendor/autoload.php';

// Preloads all of the shifts for the current user
require '../includes/shifts.inc.php';

// Gets the closest shift for the current user
require '../includes/closest.inc.php';

// Download a PDF file on POST request
require '../includes/PDFhandler.inc.php';

?>

<!DOCTYPE html>
<html lang="en">

<head>
   
    <!-- Links -->
    <?php require './layouts/links.inc.php' ?>

    <link rel="stylesheet" href="../resources/css/header-page.css">
    <link rel="stylesheet" href="../resources/css/welcome-page.css">

    <title>Welcome</title>

</head>
<body>
    <!-- Navbar -->
    <?php require('header.php') ?>

    <div class="container next-shift">

        <?php if (isset($closestShift)) { ?>

            <p><i class="fas fa-forward  faa-wrench animated"></i> Next shift:
                <?php
                echo "<b>" . $closestShift->get_ShiftType() . "  " . $closestShift->get_ShiftDate() . "</b>";
                ?>
            </p>

        <?php } ?>

    </div>

    <div class="container welcome-container">
        <table id="example" class="table table-hover table-dark">
            <thead>
                <tr>
                    <th scope="col">
                        <form class="btn-pdf" method="post">
                            <button type="submit" class="btn btn-primary">PDF</button>
                        </form>
                    </th>
                    <th scope="col">Type</th>
                    <th scope="col"> Date</th>
                    <th scope="col">Start Time</th>
                    <th scope="col">End Time</th>
                </tr>
            </thead>

            <tbody>
                <?php for ($i = 0; $i < count($shiftArray); $i++) { ?>
                    <tr>

                        <th scope="row"> <?php echo $i + 1 ?> </th>
                        <td> <?php echo $shiftArray[$i]->get_ShiftType(); ?></td>
                        <td> <?php echo $shiftArray[$i]->get_ShiftDate(); ?></td>
                        <td> <?php echo $shiftArray[$i]->get_StartTime(); ?></td>
                        <td> <?php echo $shiftArray[$i]->get_EndTime(); ?></td>
                    </tr>

                <?php  } ?>
            </tbody>

        </table>

    </div>


    <!-- Footer -->
    <?php require('footer.php') ?>

    <!-- Scripts -->
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js"></script>
    <script>
        $(document).ready(function() {
            $('#example').DataTable();
        });
    </script>


</body>
</html>