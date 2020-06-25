<?php

// Gets the closest shift
$date = new DateTime("now", new DateTimeZone('Europe/Amsterdam'));
$shtDate = $date->format('Y-m-d');
$shStart = $date->format('H:i:s');


$closestShift;

// Prepared select statement
$sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType
FROM Shift WHERE ShiftDate <= ? && StartTime <= ? && AssignedUserID = ? ORDER BY ShiftDate DESC, StartTime DESC limit 1";


if ($stmt = mysqli_prepare($link, $sql)) {

    mysqli_stmt_bind_param($stmt, "sss", $shtDate, $shStart, $_SESSION['id']);
    // Attempt to execute the prepared statement
    if (mysqli_stmt_execute($stmt)) {

        // Store result
        mysqli_stmt_store_result($stmt);

        $stmt->bind_result($Id, $shDate, $shStartTime, $shEndTime, $shType);


        if (mysqli_stmt_fetch($stmt)) {
            $closestShift = new Shift($Id, strval($shDate), strval($shStartTime), strval($shEndTime), $shType);
        }
    } else {
        echo "Oops! Something went wrong. Please try again later.";
    }

    // Close statement
    mysqli_stmt_close($stmt);
}
