<?php
function getPDF($arr)
{
    $data = "";
    $mpdf = new \Mpdf\Mpdf();
    $data .= '<h1>Shift details</h1>';

    $data .= "<table>
    <thead>
        <tr>
        <th>
        </th>
        <th>Type</th>
        <th> Date</th>
        <th>Start Time</th>
        <th>End Time</th>
        </tr>
    </thead> ";

    $data .= "<tbody>";

    for ($i = 0; $i < count($arr); $i++) {
        $data .= " <tr><th> ";
        $data .= $i . " </th>
        <td> " .  $arr[$i]->get_ShiftType() . "</td>
        <td> " . $arr[$i]->get_ShiftDate() . "</td>
        <td>" . $arr[$i]->get_StartTime() . "</td>
        <td>" . $arr[$i]->get_EndTime() . "</td>
        </tr> ";
    }
    $data .= "</tbody></table>";

    $mpdf->WriteHTML($data);
    $mpdf->Output("my-shifts-details.pdf", "D");
}

// Downloads the PDF on POST request
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    getPDF($shiftArray);
}