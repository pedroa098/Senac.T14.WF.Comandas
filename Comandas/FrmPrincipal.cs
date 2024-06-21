using Microsoft.EntityFrameworkCore;

namespace Comandas
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            CriarBancoDeDados();
        }

        // método (visibilidade=private, retorno=void no
        private void CriarBancoDeDados()
        {
            // crair uma variavel do tipo AppDbContext
            // ursar a variavel e acessar o contexto
            // executar a migração == F5
            using (var banco = new AppDbContext())
            {
                // executa a migração(CREATE TABLE Usuarios)
                banco.Database.Migrate();
            }
        }

        // evento de click
        private void btnCardapio_Click(object sender, EventArgs e)
        {
            // cria o formlario e exibe
            new FrmCardapio().ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new FrmUsuarios().ShowDialog();
        }

        private void btnComanda_Click(object sender, EventArgs e)
        {
            new FrmComanda().ShowDialog();
        }

        private void btnPedidoCozinha_Click(object sender, EventArgs e)
        {
            new FrmPedidoCozinha().ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // encerra o aplicativo 
            Application.Exit();
        }
    }
}
