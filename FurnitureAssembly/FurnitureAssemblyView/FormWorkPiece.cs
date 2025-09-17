using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using Microsoft.Extensions.Logging;

namespace FurnitureAssemblyView
{
    // ����� "���������"
    public partial class FormWorkPiece : Form
    {
        private readonly ILogger _logger;

        private readonly IWorkPieceLogic _logic;

        private int? _id;

        public int Id { set { _id = value; } }

        // �����������
        public FormWorkPiece(ILogger<FormWorkPiece> logger, IWorkPieceLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
        }

        // ��� �������� �����
        private void FormWorkPiece_Load(object sender, EventArgs e)
        {
            // �������� �� ���������� ���� id. ���� ��� ���������, �� ������� �������� ������ � ������� � �� �����
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("��������� ���������");

                    var view = _logic.ReadElement(new WorkPieceSearchModel { Id = _id.Value });

                    if (view != null)
                    {
                        textBoxName.Text = view.WorkPieceName;
                        textBoxCost.Text = view.Cost.ToString();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "������ ��������� ����������");

                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ��������� ������� ������ ���������. ���� ������� ������ ��� �������� ���������, ���� � ����������
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // �������� �� ���������� ���� � ��������� ���������
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("��������� ��������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("���������� ���������");

            try
            {
                var model = new WorkPieceBindingModel
                {
                    Id = _id ?? 0,
                    WorkPieceName = textBoxName.Text,
                    Cost = Convert.ToDouble(textBoxCost.Text)
                };

                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);

                if (!operationResult)
                {
                    throw new Exception("������ ��� ����������. �������������� ���������� � �����.");
                }

                MessageBox.Show("���������� ������ �������", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "������ ���������� ����������");

                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ��������� ������� ������ ������. ��� ������� ������ ��������� �����
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}