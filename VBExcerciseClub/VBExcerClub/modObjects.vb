Module modObjects
    Public Function SafeDate(strIn As String) As DateTime
        If strIn Is Nothing Then
            Return NULL_DATE
        End If
        Dim dt As Date = NULL_DATE
        If Date.TryParse(strIn, dt) Then
            Return dt
        Else
            'probably should give an indication of the bad date
            Return dt ' should return a null date
        End If
    End Function
End Module
