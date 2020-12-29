Public Class Form1
    Private Sub TampilFakultas()
        txtkode_fakultas.Text = oFakultas.kode_fakultas
        txtnama_fakultas.Text = oFakultas.nama_fakultas
    End Sub

    Private Sub SimpanDatafakultas()
        oFakultas.kode_fakultas = txtkode_fakultas.Text
        oFakultas.nama_fakultas = txtnama_fakultas.Text
        oFakultas.Simpan()
        Reload()
        If (oFakultas.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (oFakultas.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub

    Private Sub ClearEntry()
        txtkode_fakultas.Clear()
        txtnama_fakultas.Clear()
        txtkode_fakultas.Focus()
    End Sub

    Private Sub Hapus()
        If (fakultas_baru = False And txtkode_fakultas.Text <> "") Then
            oFakultas.Hapus(txtkode_fakultas.Text)
            ClearEntry()
            Reload()
        End If
    End Sub

    Private Sub Reload()
        oFakultas.getAllData(DataGridView1)
    End Sub

    Private Sub txtkode_fakultas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkode_fakultas.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            oFakultas.Carifakultas(txtkode_fakultas.Text)
            If (fakultas_baru = False) Then
                TampilFakultas()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If (txtkode_fakultas.Text <> "" And txtNama_Fakultas.Text <> "") Then
            SimpanDatafakultas()
            ClearEntry()
            Reload()
        Else
            MessageBox.Show("kode_fakultas dan nama_fakultas tidak boleh kosong!")
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Dim jawab As Integer
        jawab = MessageBox.Show("Apakah Data akan dihapus", "Confirm", MessageBoxButtons.YesNo)
        If (jawab = vbYes) Then
            Hapus()
        Else
            MessageBox.Show("Data batal dihapus")
        End If
    End Sub
End Class
