package com.starpanel.app.ui.runtime

import androidx.compose.foundation.layout.*
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.starpanel.app.ui.components.ConnectionStatus

@Composable
fun RuntimeScreen() {
    var currentPage by remember { mutableStateOf(0) }
    var latency by remember { mutableStateOf<Int?>(null) }

    Column(
        modifier = Modifier.fillMaxSize()
    ) {
        // Header avec statut de connexion
        Surface(
            modifier = Modifier.fillMaxWidth(),
            color = MaterialTheme.colorScheme.primaryContainer
        ) {
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(16.dp),
                horizontalArrangement = Arrangement.SpaceBetween,
                verticalAlignment = Alignment.CenterVertically
            ) {
                Text(
                    text = "Page ${currentPage + 1}",
                    style = MaterialTheme.typography.titleLarge
                )
                ConnectionStatus(
                    isConnected = true,
                    isSearching = false,
                    latency = latency
                )
            }
        }

        // Zone principale pour les widgets
        Box(
            modifier = Modifier
                .fillMaxSize()
                .weight(1f)
        ) {
            // TODO: Afficher les widgets de la page actuelle
            Text(
                text = "Widgets de la page ${currentPage + 1}",
                modifier = Modifier.padding(16.dp)
            )
        }
    }
}
