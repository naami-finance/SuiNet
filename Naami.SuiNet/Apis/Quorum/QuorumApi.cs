using Naami.SuiNet.Apis.Quorum.Requests;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.JsonRpc;
using Naami.SuiNet.Types;

namespace Naami.SuiNet.Apis.Quorum;

public class QuorumApi : IQuorumApi
{
    private readonly IJsonRpcClient _client;

    public QuorumApi(IJsonRpcClient client)
    {
        _client = client;
    }

    public Task<SuiExecuteTransactionResponse> ExecuteTransaction(
        string base64TxBytes,
        SignatureScheme signatureScheme,
        string base64Signature,
        string publicKey,
        ExecuteTransactionRequestType requestType
    ) => _client.SendAsync<
        SuiExecuteTransactionResponse,
        ExecuteTransactionRequest
    >(
        "sui_executeTransaction",
        new ExecuteTransactionRequest(
            base64TxBytes,
            signatureScheme.ToString(),
            base64Signature,
            publicKey,
            requestType.ToString()
        ));
}