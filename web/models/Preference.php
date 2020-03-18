<?php

class Preference{

    private $ID;
    private $Date;
    private $EmployeeID;
    private $Availability;


    function __construct($id, $date, $employeeId,  $availability){
        $this->ID = $id;
        $this->Date = $date;
        $this->EmployeeID = $employeeId;
        $this->Availability = $availability;
    }

}