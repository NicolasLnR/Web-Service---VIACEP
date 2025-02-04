async function buscarCep() {
    const cep = document.getElementById("cep").value;
    const resultadoDiv = document.getElementById("resultado");

    if (cep.length !== 8 || isNaN(cep)) {
        resultadoDiv.innerHTML = "<p style='color:red;'>CEP inválido! Digite apenas números.</p>";
        return;
    }

    try {
        const response = await fetch(`http://localhost:44307/api/cep/${cep}`);
        if (!response.ok) {
            throw new Error("CEP não encontrado.");
        }
        const data = await response.json();

        resultadoDiv.innerHTML = `
            <p><strong>CEP:</strong> ${data.cep}</p>
            <p><strong>Logradouro:</strong> ${data.logradouro}</p>
            <p><strong>Bairro:</strong> ${data.bairro}</p>
            <p><strong>Cidade:</strong> ${data.localidade} - ${data.uf}</p>
        `;
    } catch (error) {
        resultadoDiv.innerHTML = "<p style='color:red;'>CEP não encontrado.</p>";
    }
}
