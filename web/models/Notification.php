<?php

class Notification{

    private $ID;
    private $message;
    private $userID;


    function __construct($id, $message, $userID){
        $this->ID = $id;
        $this->message = $message;
        $this->userID = $userID; 
    }

    function get_ID(){
        return $this->ID;
    }

    function get_Message(){
        return $this->message;
    }

    function get_UserID(){
        return $this->userID;
    }
}
?>