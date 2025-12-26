package com.starpanel.app.ui.connection

import androidx.compose.foundation.layout.*
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.starpanel.app.ui.components.ConnectionStatus

@Composable
fun ConnectionScreen(
    onConnected: () -> Unit
) {
    var isSearching by remember { mutableStateOf(true) }
    var pairingCode by remember { mutableStateOf("") }
    var showPairingDialog by remember { mutableStateOf(false) }

    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Center
    ) {
        Text(
            text = "StarPanel",
            style = MaterialTheme.typography.headlineLarge
        )
        
        Spacer(modifier = Modifier.height(32.dp))
        
        ConnectionStatus(
            isConnected = false,
            isSearching = isSearching,
            latency = null
        )
        
        Spacer(modifier = Modifier.height(16.dp))
        
        if (showPairingDialog) {
            OutlinedTextField(
                value = pairingCode,
                onValueChange = { pairingCode = it },
                label = { Text("Code de pairing") },
                singleLine = true,
                maxLines = 1
            )
            
            Spacer(modifier = Modifier.height(16.dp))
            
            Button(onClick = {
                // TODO: Implémenter le pairing
                onConnected()
            }) {
                Text("Connecter")
            }
        } else {
            Button(onClick = {
                showPairingDialog = true
            }) {
                Text("Saisir le code de pairing")
            }
        }
    }
}
