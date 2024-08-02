using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comandas
{
    public partial class FrmUsuarios : Form
    {
        private bool ehNovo;

        public FrmUsuarios()
        {
            InitializeComponent();
            // metodo q lista os usuarios
            listarUsuarios();
        }

        private void listarUsuarios()
        {
            // conectar no banco
            using (var banco = new AppDbContext())
            {
                // SELECT * FROM Usuarios, msm coisa
                var usuarios = banco.Usuarios.ToList();
                // Popular a tabela na tela DataGridView
                dgvUsuarios.DataSource = usuarios;
            }
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (ehNovo)
                //metodo que ira inserir usuario no banco
                CriarUsuario();

            else
                //AtualizarUsuario();
                AtualizarUsuario();

            desabilitarCampos();
            listarUsuarios();
            limparCampos();
        }

        private void limparCampos()
        {
            txtId.TextButton = string.Empty;
            txtNome.TextButton = string.Empty;
            txtEmail.TextButton = string.Empty;
            txtSenha.TextButton = string.Empty;
        }

        private void AtualizarUsuario()
        {
            using (var banco = new AppDbContext())
            { // consulta um usuario na tabela usando o id da tela 
                var usuario = banco
                    .Usuarios
                    .Where(e => e.Id == int.Parse(txtId.TextButton))
                    .FirstOrDefault();
                usuario.Nome = txtNome.TextButton;
                usuario.Email = txtEmail.TextButton;
                usuario.Senha = txtSenha.TextButton;
                banco.SaveChanges();   
            }
        }

        private void CriarUsuario()
        {
            //acessar o banco 

            using (var banco = new AppDbContext())
            {
                //criar variavel
                var novoUsuario = new Usuario();
                novoUsuario.Nome = txtNome.TextButton;
                novoUsuario.Email = txtEmail.TextButton;
                novoUsuario.Senha = txtSenha.TextButton;
                //salvar as alterãções(INSERT INTO usuarios)
                banco.Usuarios.Add(novoUsuario);
                banco.SaveChanges();

                MessageBox.Show("Usuário cadastrado com sucesso");
            }

            //criar novo ususario 

            //salvar alterações
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ehNovo = true;
            habilitarCampos();
        }

        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtSenha.Enabled = true;
        }
        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtSenha.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // indica que está ed
            ehNovo = false;
            habilitarCampos();

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Carregarusuarios();
        }

        private void Carregarusuarios()
        {
            // conectar no banco
            using (var banco = new AppDbContext())
            {
                // realizar uma consult na tabela usuarios
                var usuarios = banco.Usuarios.ToList();
                // popular os dados do grid(dataGridView
                dgvUsuarios.DataSource = usuarios;
            }

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verifica se o indice da linha é maior ou igual a 0
            // saber se existe uma inha selecionada 
            if(e.RowIndex > 0 )
            {
                //MessageBox.Show("Linha selecionada " + (e.RowIndex + 1));

                // obter dados la linha
                var id = dgvUsuarios.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var nome = dgvUsuarios.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                var email = dgvUsuarios.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                var senha = dgvUsuarios.Rows[e.RowIndex].Cells["Senha"].Value.ToString();

                txtId.TextButton = id;
                txtNome.TextButton = nome;
                txtEmail.TextButton = email;
                txtSenha.TextButton = senha;
            }

        }
    }
}
